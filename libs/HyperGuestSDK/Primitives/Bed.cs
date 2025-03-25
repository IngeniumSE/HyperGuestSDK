// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace HyperGuestSDK;

using System.Diagnostics;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a bed.
/// </summary>
[DebuggerDisplay("{Type,nq} - {Quantity,nq}")]
public class Bed
{
	/// <summary>
	/// Gets or sets the quantity.
	/// </summary>
	[JsonPropertyName("quantity")]
	public int Quantity { get; set; }

	/// <summary>
	/// Gets or sets the bed type.
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }
}
