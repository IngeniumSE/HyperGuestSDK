// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace HyperGuestSDK;

/// <summary>
/// Represents an organization.
/// </summary>
public class Organization
{
	/// <summary>
	/// Gets or sets the organization ID.
	/// </summary>
	[JsonPropertyName("organizationId")]
	public int? OrganizationId { get; set; }

	/// <summary>
	/// Gets or sets the name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }
}
