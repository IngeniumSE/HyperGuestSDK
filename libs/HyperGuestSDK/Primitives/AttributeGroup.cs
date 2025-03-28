// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HyperGuestSDK;

/// <summary>
/// Represents a group of attributes.
/// </summary>
[DebuggerDisplay("{Group,nq} - {Items,nq}")]
public class AttributeGroup
{
	[JsonPropertyName("group")]
	public string Group { get; set; } = default!;

	[JsonPropertyName("items")]
	[JsonConverter(typeof(AttributeItemsTypeConverter))]
	public AttributeItems Items { get; set; } = default!;
}

/// <summary>
/// Represents set of attribute values.
/// </summary>
[DebuggerDisplay("{IsMap ? \"Map\" : \"Set\",nq} ({Count,nq} items)")]
public class AttributeItems(
	string?[]? valuesArray,
	Dictionary<string, string?>? valuesDictionary)
{
	readonly string?[]? _valuesArray = valuesArray;
	readonly Dictionary<string, string?>? _valuesDictionary = valuesDictionary;

	public bool IsMap => _valuesDictionary is not null;
	public int Count => _valuesArray?.Length ?? _valuesDictionary?.Count ?? 0;

	public IEnumerable<string?> Enumerate() => (_valuesArray ?? Array.Empty<string?>());
	public IEnumerable<KeyValuePair<string, string?>> EnumerateMap() => (_valuesDictionary ?? Enumerable.Empty<KeyValuePair<string, string?>>());

	public string?[] AsArray() => _valuesArray ?? Array.Empty<string?>();
	public Dictionary<string, string?> AsMap() => _valuesDictionary ?? new Dictionary<string, string?>();
}

public class AttributeItemsTypeConverter : JsonConverter<AttributeItems>
{
	public override AttributeItems? Read(
		ref Utf8JsonReader reader,
		Type typeToConvert,
		JsonSerializerOptions options)
	{
		using var doc = JsonDocument.ParseValue(ref reader);
		if (doc.RootElement.ValueKind != JsonValueKind.Array)
		{
			return null;
		}

		string?[]? valuesArray = null;
		Dictionary<string, string?>? valuesDictionary = null;

		int length = doc.RootElement.GetArrayLength();
		for (int i = 0; i < length; i++)
		{
			var node = doc.RootElement[i];
			switch (node.ValueKind)
			{
				case JsonValueKind.Object:
					{
						string key = node.GetProperty("key").GetString()!;
						string value = node.GetProperty("value").GetString()!;

						if (valuesDictionary is null)
						{
							valuesDictionary = new Dictionary<string, string?>(capacity: length);
						}

						valuesDictionary[key] = value;

						break;
					}
				case JsonValueKind.String:
					{
						if (valuesArray is null)
						{
							valuesArray = new string[length];
						}
						valuesArray[i] = node.GetString()!;

						var value = node.GetString();
						break;
					}
			}
		}

		return new AttributeItems(valuesArray, valuesDictionary);
	}

	public override void Write(Utf8JsonWriter writer, AttributeItems value, JsonSerializerOptions options)
	{
		if (value.IsMap)
		{
			writer.WriteStartArray();
			foreach (var item in value.EnumerateMap())
			{
				writer.WriteStartObject();
				writer.WriteString("key", item.Key);
				writer.WriteString("value", item.Value);
				writer.WriteEndObject();
			}
			writer.WriteEndArray();
		}
		else
		{
			writer.WriteStartArray();
			foreach (var item in value.Enumerate())
			{
				writer.WriteStringValue(item);
			}
			writer.WriteEndArray();
		}
	}
}
