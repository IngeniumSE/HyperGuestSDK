// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace HyperGuestSDK;

/// <summary>
/// Represents a set of coordinates.
/// </summary>
public struct Coordinates
{
	/// <summary>
	/// Gets or sets the latitude.
	/// </summary>
	[JsonPropertyName("latitude")]
	public double Latitude { get; set; }

	/// <summary>
	/// Gets or sets the longitude.
	/// </summary>
	[JsonPropertyName("longitude")]
	public double Longitude { get; set; }
}
