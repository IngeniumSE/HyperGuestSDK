// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Diagnostics;
using System.Text.Json.Serialization;

namespace HyperGuestSDK.Api;

[DebuggerDisplay("[{HotelId,nq}] {name,nq}, {city,nq}, {country,nq}")]
public class Property : Model<Property>
{
	[JsonPropertyName("city")]
	public string? City { get; set; }

	[JsonPropertyName("city_id")]
	public int? CityId { get; set; }

	[JsonPropertyName("country")]
	public string? Country { get; set; }

	[JsonPropertyName("hotel_id")]
	public int HotelId { get; set; }

	[JsonPropertyName("last_updated")]
	public DateTimeOffset? LastUpdated { get; set; }

	[JsonPropertyName("name")]
	public required string Name { get; set; }

	[JsonPropertyName("region")]
	public string? Region { get; set; }
}
