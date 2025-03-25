// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace HyperGuestSDK;

using System.Text.Json.Serialization;

/// <summary>
/// Represents a pair of dates.
/// </summary>
public struct Dates
{
	/// <summary>
	/// Gets or sets the end date.
	/// </summary>
	[JsonPropertyName("end")]
	public DateTime? End { get; set; }

	/// <summary>
	/// Gets or sets the start date.
	/// </summary>
	[JsonPropertyName("start")]
	public DateTime? Start { get; set; }
}
