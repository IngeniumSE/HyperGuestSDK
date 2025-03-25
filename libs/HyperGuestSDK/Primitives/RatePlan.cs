// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace HyperGuestSDK;

/// <summary>
/// Represents a rate plan.
/// </summary>
public class RatePlan
{
	/// <summary>
	/// Gets or sets the base rate plan ID.
	/// </summary>
	[JsonPropertyName("baseRatePlanId")]
	public int? BaseRatePlanId { get; set; }

	/// <summary>
	/// Gets or sets the base rate plan PMS code.
	/// </summary>
	[JsonPropertyName("baseRatePlanPmsCode")]
	public string? BaseRatePlanPmsCode { get; set; }

	/// <summary>
	/// Gets or sets the rate plan description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets whether this is a private rate plan.
	/// </summary>
	[JsonPropertyName("isPrivate")]
	public bool IsPrivate { get; set; }

	/// <summary>
	/// Gets or sets whether this is a rate plan that can receive push updates.
	/// </summary>
	[JsonPropertyName("isPushable")]
	public bool IsPushable { get; set; }

	/// <summary>
	/// Gets or sets the rate plan name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the PMS code.
	/// </summary>
	[JsonPropertyName("pmsCode")]
	public string? PmsCode { get; set; }

	/// <summary>
	/// Gets or sets the rate plan ID.
	/// </summary>
	[JsonPropertyName("id")]
	public int RatePlanId { get; set; }

	/// <summary>
	/// Gets or sets the policies for this rate plan.
	/// </summary>
	[JsonPropertyName("policies")]
	public Policy[]? Policies { get; set; }

	/// <summary>
	/// Gets the rate plan settings.
	/// </summary>
	[JsonPropertyName("settings")]
	public RatePlanSettings? Settings { get; set; }

	/// <summary>
	/// Gets or sets the tags.
	/// </summary>
	[JsonPropertyName("tags")]
	public string[]? Tags { get; set; }

	/// <summary>
	/// Gets or sets the rate plan type.
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }
}

/// <summary>
/// Gets or sets the rate plan settings.
/// </summary>
public class RatePlanSettings
{
	/// <summary>
	/// Gets the board.
	/// </summary>
	[JsonPropertyName("board")]
	public Board? Board { get; set; }

	/// <summary>
	/// Gets or sets the charge.
	/// </summary>
	[JsonPropertyName("charge")]
	public string? Charge { get; set; }

	/// <summary>
	/// Gets or sets the price type.
	/// </summary>
	[JsonPropertyName("priceType")]
	public string? PriceType { get; set; }

	/// <summary>
	/// Gets or sets the status.
	/// </summary>
	[JsonPropertyName("status")]
	public string? Status { get; set; }
}
