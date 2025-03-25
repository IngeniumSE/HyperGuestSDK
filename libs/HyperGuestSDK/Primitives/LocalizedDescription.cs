// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace HyperGuestSDK;

using System.Diagnostics;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a description.
/// </summary>
[DebuggerDisplay("{Type,nq} - {Language,nq}")]
public class LocalizedDescription
{
	/// <summary>
	/// Gets or sets the description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the language.
	/// </summary>
	[JsonPropertyName("language")]
	public string? Language { get; set; }

	/// <summary>
	/// Gets or sets the room ID.
	/// </summary>
	[JsonPropertyName("roomId")]
	public int? RoomId { get; set; }

	/// <summary>
	/// Gets or sets the type.
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }
}
