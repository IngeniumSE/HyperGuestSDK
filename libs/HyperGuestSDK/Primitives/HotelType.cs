// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace HyperGuestSDK;

/// <summary>
/// Represents a hotel type.
/// </summary>
public class HotelType
{
	/// <summary>
	/// Gets or sets the hotel type ID.
	/// </summary>
	[JsonPropertyName("id")]
	public int? HotelTypeId { get; set; }

	/// <summary>
	/// Gets or sets the name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }
}
