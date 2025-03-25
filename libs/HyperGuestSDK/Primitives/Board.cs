// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace HyperGuestSDK;

using System.Diagnostics;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a board
/// </summary>
[DebuggerDisplay("{Code,nq}")]
public class Board
{
	/// <summary>
	/// Gets or sets the board code.
	/// </summary>
	[JsonPropertyName("code")]
	public string? Code { get; set; }

	/// <summary>
	/// Gets or sets the board description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }
}
