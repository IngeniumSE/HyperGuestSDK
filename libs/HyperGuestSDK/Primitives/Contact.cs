// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace HyperGuestSDK;

/// <summary>
/// Represents a contact.
/// </summary>
public class Contact
{
	/// <summary>
	/// Gets or sets the email address.
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary>
	/// Gets or sets the telephone number.
	/// </summary>
	[JsonPropertyName("phone")]
	public string? Phone { get; set; }

	/// <summary>
	/// Gets or sets the website.
	/// </summary>
	[JsonPropertyName("website")]
	public string? Website { get; set; }
}
