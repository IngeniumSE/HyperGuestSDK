// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace HyperGuestSDK.Ari;

/// <summary>
/// Represents a model for an ARI update, containing property-specific update records and related metadata.
/// </summary>
public class AriUpdate : Model<AriUpdate>
{
	/// <summary>
	/// Gets or sets the collection of ARI update records associated with the date.
	/// </summary>
	[JsonPropertyName("ARIUpdate")]
	public AriDateUpdate[]? DateUpdates { get; set; }

	/// <summary>
	/// Gets or sets the unique identifier for the property.
	/// </summary>
	[JsonPropertyName("propertyId")]
	public int PropertyId { get; set; }
}

/// <summary>
/// Represents an ARI (Availability, Rates, and Inventory) update for a specific room and date or date range.
/// </summary>
/// <remarks>This class is typically used to transmit or store information about room availability and related
/// details for a given date or range of dates. All properties correspond to fields commonly used in ARI systems for
/// hotel inventory management. Instances may be used when synchronizing availability data with external systems or
/// APIs.</remarks>
public class AriDateUpdate : Model<AriDateUpdate>
{
	/// <summary>
	/// Gets or sets the date associated with this ARI update.
	/// </summary>
	[JsonPropertyName("date")]
	public DateTime? Date { get; set; }

	/// <summary>
	/// Gets or sets the date range for this ARI update.
	/// </summary>
	[JsonPropertyName("dates")]
	public DatePair? Dates { get; set; }

	/// <summary>
	/// Gets or sets the number of rooms currently available for booking.
	/// </summary>
	[JsonPropertyName("numberOfAvailableRooms")]
	public int? NumberOfAvailableRooms { get; set; }

	/// <summary>
	/// Gets or sets the collection of rate plans to be updated for the specified dates.
	/// </summary>
	[JsonPropertyName("ratePlans")]
	public AriDateRatePlan[]? RatePlans { get; set; }

	/// <summary>
	/// Gets or sets the unique identifier for the room.
	/// </summary>
	[JsonPropertyName("roomId")]
	public int RoomId { get; set; }

	/// <summary>
	/// Gets or sets the code that uniquely identifies the type of room.
	/// </summary>
	[JsonPropertyName("roomTypeCode")]
	public string? RoomTypeCode { get; set; }
}

/// <summary>
/// Represents the availability and booking restrictions for a rate plan on specific dates, including open status,
/// length-of-stay limits, and associated pricing details.
/// </summary>
/// <remarks>Use this class to specify or query the rules and pricing for a rate plan on a given date, such as
/// whether bookings are allowed, minimum and maximum stay requirements, and price information. All properties are
/// optional and may be null if not applicable for a particular rate plan or date.</remarks>
public class AriDateRatePlan : Model<AriDateRatePlan>
{
	/// <summary>
	/// Gets or sets a value indicating whether the rate plan is open for booking.
	/// </summary>
	[JsonPropertyName("isOpen")]
	public bool? IsOpen { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the location is open upon arrival.
	/// </summary>
	[JsonPropertyName("isOpenOnArrival")]
	public bool? IsOpenOnArrival { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the location is open at the time of departure.
	/// </summary>
	[JsonPropertyName("isOpenOnDeparture")]
	public bool? IsOpenOnDeparture { get; set; }

	/// <summary>
	/// Gets or sets the number of days before arrival that a booking can be made.
	/// </summary>
	[JsonPropertyName("lastMinute")]
	public int? LastMinute { get; set; }

	/// <summary>
	/// Gets or sets the maximum number of consecutive nights a guest may stay.
	/// </summary>
	[JsonPropertyName("maxLOS")]
	public int? MaximumLengthOfStay { get; set; }

	/// <summary>
	/// Gets or sets the maximum number of nights allowed for a stay, including the check-out date.
	/// </summary>
	[JsonPropertyName("maxStayThrough")]
	public int? MaximumStayThrough { get; set; }

	/// <summary>
	/// Gets or sets the minimum number of consecutive nights required for a stay.
	/// </summary>
	[JsonPropertyName("minLOS")]
	public int? MinimumLengthOfStay { get; set; }

	/// <summary>
	/// Gets or sets the minimum number of consecutive nights required for a stay, including the specified end date.
	/// </summary>
	[JsonPropertyName("minStayThrough")]
	public int? MinimumStayThrough { get; set; }

	/// <summary>
	/// Gets or sets the collection of price details associated with the rate plan for specific dates.
	/// </summary>
	[JsonPropertyName("prices")]
	public AriDateRatePlanPrice[]? Prices { get; set; }

	/// <summary>
	/// Gets or sets the code that uniquely identifies the rate plan.
	/// </summary>
	[JsonPropertyName("ratePlanCode")]
	public string? RatePlanCode { get; set; }

	/// <summary>
	/// Gets or sets the release period in days before which a booking can be made.
	/// </summary>
	[JsonPropertyName("release")]
	public int? Release { get; set; }
}

/// <summary>
/// Represents the pricing details for a specific rate plan on a given date, including guest occupancy information.	
/// </summary>
public class AriDateRatePlanPrice : Model<AriDateRatePlanPrice>
{
	/// <summary>
	/// Gets or sets the guest occupancy details associated with the rate plan.
	/// </summary>
	[JsonPropertyName("numberOfGuests")]
	public AriDateRatePlanGuests? NumberOfGuests { get; set; }

	/// <summary>
	/// Gets or sets the price value associated with the item.
	/// </summary>
	[JsonPropertyName("price")]
	public decimal Price { get; set; }
}

/// <summary>
/// Represents the guest composition for a rate plan on a specific date, including the number of adults, children, and
/// infants.
/// </summary>
/// <param name="Adults">The number of adult guests included in the rate plan. Must be zero or greater.</param>
/// <param name="Children">The number of child guests included in the rate plan. Can be null if not specified; otherwise, must be zero or
/// greater.</param>
/// <param name="Infants">The number of infant guests included in the rate plan. Can be null if not specified; otherwise, must be zero or
/// greater.</param>
public record AriDateRatePlanGuests(
	[property: JsonPropertyName("adults")] int Adults,
	[property: JsonPropertyName("children")] int? Children,
	[property: JsonPropertyName("infants")] int? Infants);

/// <summary>
/// Represents a pair of dates indicating a start and end period.
/// </summary>
/// <param name="From">The start date of the period.</param>
/// <param name="To">The end date of the period.</param>
public record DatePair(
	[property: JsonPropertyName("from")] DateTime From,
	[property: JsonPropertyName("to")] DateTime To);
