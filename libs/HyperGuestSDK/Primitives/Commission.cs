// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace HyperGuestSDK;

/// <summary>
/// Represents commission details.
/// </summary>
public class Commission
{
	/// <summary>
	/// Gets or sets the calculation.
	/// </summary>
	[JsonPropertyName("calculation")]
	public string? Calculation { get; set; }

	/// <summary>
	/// Gets or sets the charge type.
	/// </summary>
	[JsonPropertyName("chargeType")]
	public string? ChargeType { get; set; }

	/// <summary>
	/// Gets or sets the commission value.
	/// </summary>
	[JsonPropertyName("value")]
	public decimal? Value { get; set; }
}
