// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace HyperGuestSDK;

using System.Diagnostics;
using System.Text.Json.Serialization;

/// <summary>
/// Represents an image.
/// </summary>
[DebuggerDisplay("{Uri,nq}")]
public class Image
{
	/// <summary>
	/// Gets or sets the created date.
	/// </summary>
	[JsonPropertyName("created")]
	public DateTimeOffset Created { get; set; }

	/// <summary>
	/// Gets or sets the image description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the image ID.
	/// </summary>
	[JsonPropertyName("id")]
	public long ImageId { get; set; }

	/// <summary>
	/// Gets or sets the image priority.
	/// </summary>
	[JsonPropertyName("priority")]
	public int Priority { get; set; }

	/// <summary>
	/// Gets or sets the rate type.
	/// </summary>
	[JsonPropertyName("rateType")]
	public string? RateType { get; set; }

	/// <summary>
	/// Gets or sets the image size.
	/// </summary>
	[JsonPropertyName("size")]
	public ImageSize? Size { get; set; }

	/// <summary>
	/// Gets or sets the tags.
	/// </summary>
	[JsonPropertyName("tags")]
	public string[]? Tags { get; set; }

	/// <summary>
	/// Gets or sets the image type.
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	/// Gets or sets the updated date.
	/// </summary>
	[JsonPropertyName("updated")]
	public DateTimeOffset? Updated { get; set; }

	/// <summary>
	/// Gets or sets the image URI.
	/// </summary>
	[JsonPropertyName("uri")]
	public string? Uri { get; set; }
}

/// <summary>
/// Represents an image size.
/// </summary>
[DebuggerDisplay("{Width,nq}x{Height,nq}")]
public struct ImageSize
{
	/// <summary>
	/// Gets or sets the height.
	/// </summary>
	[JsonPropertyName("height")]
	public int Height { get; set; }

	/// <summary>
	/// Gets or sets the width.
	/// </summary>
	[JsonPropertyName("width")]
	public int Width { get; set; }
}
