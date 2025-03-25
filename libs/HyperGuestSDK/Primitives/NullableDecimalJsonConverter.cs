// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace HyperGuestSDK;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class NullableDecimalJsonConverter : JsonConverter<decimal?>
{
	public override decimal? Read(
		ref Utf8JsonReader reader,
		Type typeToConvert,
		JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.String)
		{
			var value = reader.GetString();
			if (decimal.TryParse(value, out decimal result))
			{
				return result;
			}
		}
		else if (reader.TokenType == JsonTokenType.Number)
		{
			return reader.GetDecimal();
		}

		return null;
	}

	public override void Write(Utf8JsonWriter writer, decimal? value, JsonSerializerOptions options)
		=> throw new NotSupportedException();
}
