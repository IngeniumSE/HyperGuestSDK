// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HyperGuestSDK;

public class TimeSpanJsonConverter() : JsonConverter<TimeSpan?>
{
	readonly string _format = "hh\\:mm";

	public override TimeSpan? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		string? value = reader.GetString();
		if (TimeSpan.TryParseExact(value, _format, CultureInfo.InvariantCulture, out TimeSpan result))
		{
			return result;
		}

		return null;
	}

	public override void Write(Utf8JsonWriter writer, TimeSpan? value, JsonSerializerOptions options)
	{
		if (value.HasValue)
		{
			writer.WriteStringValue(value.Value.ToString(_format));
		}
		else
		{
			writer.WriteNullValue();
		}
	}
}
