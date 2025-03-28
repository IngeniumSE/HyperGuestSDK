// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace HyperGuestSDK;

public class BitJsonConverter() : JsonConverter<bool>
{
	public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		int value = reader.GetInt32();

		return value > 0;
	}

	public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
	{
		writer.WriteNumberValue(value ? 1 : 0);
	}
}
