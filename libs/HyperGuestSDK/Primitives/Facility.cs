// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace HyperGuestSDK;

using System.Diagnostics;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a facility.
/// </summary>
[DebuggerDisplay("{Name,nq} ({Category,nq}, {Classification,nq})")]
public class Facility
{
	/// <summary>
	/// Gets or sets the facility category.
	/// </summary>
	[JsonPropertyName("category")]
	public string? Category { get; set; }

	/// <summary>
	/// Gets or sets the facility category slug.
	/// </summary>
	[JsonPropertyName("categorySlug")]
	public string? CategorySlug { get; set; }

	/// <summary>
	/// Gets or sets the facility classification.
	/// </summary>
	[JsonPropertyName("classification")]
	public string? Classification { get; set; }

	/// <summary>
	/// Gets or sets the facility ID.
	/// </summary>
	[JsonPropertyName("id")]
	public int FacilityId { get; set; }

	/// <summary>
	/// Gets or sets the facility name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the facility name slug.
	/// </summary>
	[JsonPropertyName("nameSlug")]
	public string? NameSlug { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the facility is popular.
	/// </summary>
	[JsonPropertyName("popular")]
	[JsonConverter(typeof(BitJsonConverter))]
	public bool Popular { get; set; }

	/// <summary>
	/// Gets or sets the facility type.
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }
}
