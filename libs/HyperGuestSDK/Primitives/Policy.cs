// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace HyperGuestSDK;

using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a policy.
/// </summary>
[DebuggerDisplay("{PolicyId,nq} - {Name,nq} ({Type,nq})")]
public class Policy
{
	/// <summary>
	/// Gets or sets the policy condition.
	/// </summary>
	[JsonPropertyName("condition")]
	[JsonConverter(typeof(PolicyConditionJsonConverter))]
	public PolicyCondition[]? Condition { get; set; }

	/// <summary>
	/// Gets or sets the set of dates.
	/// </summary>
	[JsonPropertyName("dates")]
	public Dates? Dates { get; set; }

	/// <summary>
	/// Gets or sets the policy name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the policy ID.
	/// </summary>
	[JsonPropertyName("id")]
	public int PolicyId { get; set; }

	/// <summary>
	/// Gets ro sets the policy result.
	/// </summary>
	[JsonPropertyName("result")]
	[JsonConverter(typeof(PolicyResultJsonConverter))]
	public PolicyResult[]? Result { get; set; }

	/// <summary>
	/// Gets or sets the policy type.
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }
}

/// <summary>
/// Represents a condition for a policy.
/// </summary>
public class PolicyCondition
{
	/// <summary>
	/// Gets or sets the minimum number of days for a days-before policy.
	/// </summary>
	[JsonPropertyName("From_Day")]
	public int? FromDay { get; set; }

	/// <summary>
	/// Gets or sets the minimum number of days for a maximum-length-of-stay policy.
	/// </summary>
	[JsonPropertyName("Min_Days")]
	public int? MinDays { get; set; }

	/// <summary>
	/// Gets or sets the set of nationalities that satisfy this condition.
	/// </summary>
	[JsonPropertyName("nationalities")]
	public string[]? Nationalities { get; set; }

	/// <summary>
	/// Gets or sets the maximum number of days for a days-before policy.
	/// </summary>
	[JsonPropertyName("To_Day")]
	public int? ToDay { get; set; }

	/// <summary>
	/// Gets or sets the weekdays for a weekdays policy.
	/// </summary>
	[JsonPropertyName("weekdays")]
	public string[]? Weekdays { get; set; }
}

/// <summary>
/// Represents the result of a policy.
/// </summary>
public class PolicyResult
{
	/// <summary>
	/// Gets or sets the minimum check-in age.
	/// </summary>
	[JsonPropertyName("Age")]
	public int? Age { get; set; }

	/// <summary>
	/// Gets or sets the amount.
	/// </summary>
	[JsonPropertyName("Amount")]
	[JsonConverter(typeof(NullableDecimalJsonConverter))]
	public decimal? Amount { get; set; }

	/// <summary>
	/// Gets or sets the supported cards.
	/// </summary>
	[JsonPropertyName("Card")]
	public string[]? Cards { get; set; }

	/// <summary>
	/// Gets or sets the charge type.
	/// </summary>
	[JsonPropertyName("Charge_Type")]
	public string? ChargeType { get; set; }

	/// <summary>
	/// Gets or sets the cancellation days.
	/// </summary>
	[JsonPropertyName("Days_Before")]
	public int? DaysBefore { get; set; }

	/// <summary>
	/// Gets or sets the description.
	/// </summary>
	[JsonPropertyName("Description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets whether the reservation will be immediately confirmed.
	/// </summary>
	[JsonPropertyName("Is_Immediate")]
	public bool? IsImmediate { get; set; }

	/// <summary>
	/// Gets or sets the penalty type.
	/// </summary>
	[JsonPropertyName("Penalty_Type")]
	public string? PenaltyType { get; set; }

	/// <summary>
	/// Gets or sets the penalty value.
	/// </summary>
	[JsonPropertyName("Penalty_Value")]
	[JsonConverter(typeof(NullableDecimalJsonConverter))]
	public decimal? PenaltyValue { get; set; }

	/// <summary>
	/// Gets or sets the status.
	/// </summary>
	[JsonPropertyName("status")]
	public string? Status { get; set; }	

	/// <summary>
	/// Gets or sets the time (in days or hours) before check-in.
	/// </summary>
	[JsonPropertyName("Time_Before_Check_In")]
	public int? TimeBeforeCheckIn { get; set; }

	/// <summary>
	/// Gets or sets the time unit (days or hours).
	/// </summary>
	[JsonPropertyName("Time_Before_Check_In_Type")]
	public string? TimeBeforeCheckInType { get; set; }

	/// <summary>
	/// Gets or sets the title.
	/// </summary>
	[JsonPropertyName("Title")]
	public string? Title { get; set; }
}

/// <summary>
/// Represents known policy types.
/// </summary>
public static class KnownPolicyTypes
{
	public const string Cancellation = "cancellation";
	public const string DaysBefore = "days-before";
	public const string General = "general";
	public const string ImmediateConfirmation = "immediate-confirmation";
	public const string MaximumLengthOfStay = "maximum-length-of-stay";
	public const string MinimumCheckInAge = "minimum-check-in-age";
	public const string MinimumLengthOfStay = "minimum-length-of-stay";
	public const string Nationality = "nationality";
	public const string PropertyRemark = "property-remark";
	public const string SupportedCards = "supported-cards";
	public const string Weekdays = "weekdays";
}

/// <summary>
/// Represents known penalty types.
/// </summary>
public static class KnownPenalityTypes
{
	public const string Percent = "percent";
	public const string Fixed = "fixed";
}

/// <summary>
/// Represents known time units.
/// </summary>
public static class KnownTimeUnits
{
	public const string Days = "days";
	public const string Hours = "hours";
}

/// <summary>
/// Represents known statuses.
/// </summary>
public static class KnownStatuses
{
	public const string Enabled = "enabled";
	public const string Disabled = "disabled";
}

public class PolicyConditionJsonConverter : JsonConverter<PolicyCondition[]?>
{
	public override PolicyCondition[]? Read(
		ref Utf8JsonReader reader,
		Type typeToConvert,
		JsonSerializerOptions options)
	{
		using var doc = JsonDocument.ParseValue(ref reader);
		if (doc.RootElement.ValueKind == JsonValueKind.Object)
		{
			return [doc.Deserialize<PolicyCondition>()!];
		}
		else if (doc.RootElement.ValueKind == JsonValueKind.Array)
		{
			return doc.Deserialize<PolicyCondition[]>();
		}

		return null;
	}

	public override void Write(Utf8JsonWriter writer, PolicyCondition[]? value, JsonSerializerOptions options)
		=> throw new NotSupportedException();
}

public class PolicyResultJsonConverter : JsonConverter<PolicyResult[]?>
{
	public override PolicyResult[]? Read(
		ref Utf8JsonReader reader,
		Type typeToConvert,
		JsonSerializerOptions options)
	{
		using var doc = JsonDocument.ParseValue(ref reader);
		if (doc.RootElement.ValueKind == JsonValueKind.Object)
		{
			return [doc.Deserialize<PolicyResult>()!];
		}
		else if (doc.RootElement.ValueKind == JsonValueKind.Array)
		{
			return doc.Deserialize<PolicyResult[]>();
		}

		return null;
	}

	public override void Write(Utf8JsonWriter writer, PolicyResult[]? value, JsonSerializerOptions options)
		=> throw new NotSupportedException();
}
