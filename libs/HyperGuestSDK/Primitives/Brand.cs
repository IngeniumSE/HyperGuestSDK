// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace HyperGuestSDK;

/// <summary>
/// Represents a brand.
/// </summary>
public class Brand
{
	/// <summary>
	/// Gets or sets the brand ID.
	/// </summary>
	[JsonPropertyName("brandId")]
	public int? BrandId { get; set; }

	/// <summary>
	/// Gets or sets the name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }
}
