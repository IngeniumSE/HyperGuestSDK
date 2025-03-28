// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Diagnostics;
using System.Text.Json.Serialization;

namespace HyperGuestSDK.Api;

/// <summary>
/// Represents the details of a property.
/// </summary>
public class PropertyDetail : Model<PropertyDetail>
{
	/// <summary>
	/// Gets or sets whether bookings can be sold for this property.
	/// </summary>
	[JsonPropertyName("allowSell")]
	public bool AllowSell { get; set; }

	/// <summary>
	/// Gets or sets the ARI type.
	/// </summary>
	[JsonPropertyName("ariType")]
	public string? AriType { get; set; }

	/// <summary>
	/// Gets or sets the attributes.
	/// </summary>
	[JsonPropertyName("attributes")]
	public AttributeGroup[]? Attributes { get; set; }

	/// <summary>
	/// Gets or sets the child price type.
	/// </summary>
	[JsonPropertyName("childPriceType")]
	public string? ChildPriceType { get; set; }

	/// <summary>
	/// Gets or sets the contact.
	/// </summary>
	[JsonPropertyName("contact")]
	public Contact? Contact { get; set; }

	/// <summary>
	/// Gets or sets the coordinates.
	/// </summary>
	[JsonPropertyName("coordinates")]
	public Coordinates? Coordinates { get; set; }

	/// <summary>
	/// Gets or sets the commission details.
	/// </summary>
	[JsonPropertyName("commission")]
	public Commission? Commission { get; set; }

	/// <summary>
	/// Gets or sets the created date.
	/// </summary>
	[JsonPropertyName("created")]
	[JsonConverter(typeof(DateTimeJsonConverter))]
	public DateTime? Created { get; set; }

	/// <summary>
	/// Gets or sets the descriptions.
	/// </summary>
	[JsonPropertyName("descriptions")]
	public LocalizedDescription[]? Descriptions { get; set; }	

	/// <summary>
	/// Gets or sets the facilities.
	/// </summary>
	[JsonPropertyName("facilities")]
	public Facility[]? Facilities { get; set; }

	/// <summary>
	/// Gets or sets the hotel ID.
	/// </summary>
	[JsonPropertyName("id")]
	public int HotelId { get; set; }

	/// <summary>
	/// Gets or sets the images.
	/// </summary>
	[JsonPropertyName("images")]
	public Image[]? Images { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the property is a test property.
	/// </summary>
	[JsonPropertyName("isTest")]
	[JsonConverter(typeof(BitJsonConverter))]
	public bool IsTest { get; set; }

	/// <summary>
	/// Gets or sets the logo.
	/// </summary>
	[JsonPropertyName("logo")]	
	public string? Logo { get; set; }

	/// <summary>
	/// Gets or sets the name.
	/// </summary>
	[JsonPropertyName("name")]
	public string Name { get; set; } = default!;

	/// <summary>
	/// Gets or sets the set of rate plans.
	/// </summary>
	[JsonPropertyName("ratePlans")]
	public RatePlan?[]? RatePlans { get; set; }

	/// <summary>
	/// Gets or sets the rooms.
	/// </summary>
	[JsonPropertyName("rooms")]
	public PropertyRoom[]? Rooms { get; set; }

	/// <summary>
	/// Gets or sets the settings.
	/// </summary>
	[JsonPropertyName("settings")]
	public PropertySettings? Settings { get; set; }

	/// <summary>
	/// Gets or sets the status.
	/// </summary>
	[JsonPropertyName("status")]
	public string? Status { get; set; }

	/// <summary>
	/// Gets or sets the tags.
	/// </summary>
	[JsonPropertyName("tags")]
	public string[]? Tags { get; set; }

	/// <summary>
	/// Gets or sets the updated date.
	/// </summary>
	[JsonPropertyName("updated")]
	[JsonConverter(typeof(DateTimeJsonConverter))]
	public DateTime? Updated { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether to use pax conversion.
	/// </summary>
	[JsonPropertyName("usePaxConversion")]
	public bool UsePaxConversion { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether to use price per room.
	/// </summary>
	[JsonPropertyName("usePricePerRoom")]
	public bool UsePricePerRoom { get; set; }
}

/// <summary>
/// Represents the property settings.
/// </summary>
public class PropertySettings
{
	/// <summary>
	/// Gets or sets the brand.
	/// </summary>
	[JsonPropertyName("brand")]
	public Brand? Brand { get; set; }

	/// <summary>
	/// Gets or sets the chain.
	/// </summary>
	[JsonPropertyName("chain")]
	public Organization? Chain { get; set; }

	/// <summary>
	/// Gets or sets the check-in time.
	/// </summary>
	[JsonPropertyName("checkIn")]
	[JsonConverter(typeof(TimeSpanJsonConverter))]
	public TimeSpan? CheckIn { get; set; }

	/// <summary>
	/// Gets or sets the check-out time.
	/// </summary>
	[JsonPropertyName("checkOut")]
	[JsonConverter(typeof(TimeSpanJsonConverter))]
	public TimeSpan? CheckOut { get; set; }

	/// <summary>
	/// Gets or sets the currency.
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// Gets or sets the cut-off time.
	/// </summary>
	[JsonPropertyName("cutOff")]
	[JsonConverter(typeof(TimeSpanJsonConverter))]
	public TimeSpan? CutOff { get; set; }

	/// <summary>
	/// Gets or sets the property group.
	/// </summary>
	[JsonPropertyName("group")]
	public string? Group { get; set; }

	/// <summary>
	/// Gets or sets the hotel type.
	/// </summary>
	[JsonPropertyName("hotelType")]
	public HotelType? HotelType { get; set; }

	/// <summary>
	/// Gets or sets the max child age.
	/// </summary>
	[JsonPropertyName("maxChildAge")]
	public int? MaxChildAge { get; set; }

	/// <summary>
	/// Gets or sets the max infant age.
	/// </summary>
	[JsonPropertyName("maxInfantAge")]
	public int? MaxInfantAge { get; set; }

	/// <summary>
	/// Gets or sets the number of floors.
	/// </summary>
	[JsonPropertyName("numberOfFloors")]
	public int? NumberOfFloors { get; set; }

	/// <summary>
	/// Gets or sets the number of rooms.
	/// </summary>
	[JsonPropertyName("numberOfRooms")]
	public int? NumberOfRooms { get; set; }

	/// <summary>
	/// Gets or sets the rating.
	/// </summary>
	[JsonPropertyName("rating")]
	public int? Rating { get; set; }

	/// <summary>
	/// Gets or sets the time zone.
	/// </summary>
	[JsonPropertyName("timezone")]
	public string? TimeZone { get; set; }

	/// <summary>
	/// Gets or sets the UTC offset.
	/// </summary>
	[JsonPropertyName("utcOffset")]
	public int? UtcOffset { get; set; }
}

/// <summary>
/// Represents a property room.
/// </summary>
[DebuggerDisplay("{RoomId,nq} - {Name,nq} ({Type,nq}, {PmsCode,nq})")]
public class PropertyRoom
{
	/// <summary>
	/// Gets or sets the beds.
	/// </summary>
	[JsonPropertyName("beds")]
	public Bed[]? Beds { get; set; }

	/// <summary>
	/// Gets or sets the descriptions.
	/// </summary>
	[JsonPropertyName("descriptions")]
	public LocalizedDescription[]? Descriptions { get; set; }

	/// <summary>
	/// Gets or sets the facilities.
	/// </summary>
	[JsonPropertyName("facilities")]
	public Facility[]? Facilities { get; set; }

	/// <summary>
	/// Gets or sets the hotel ID.
	/// </summary>
	[JsonPropertyName("hotelId")]
	public int HotelId { get; set; }

	/// <summary>
	/// Gets or sets the images.
	/// </summary>
	[JsonPropertyName("images")]
	public Image[]? Images { get; set; }

	/// <summary>
	/// Gets or sets the room name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the PMS code.
	/// </summary>
	[JsonPropertyName("pmsCode")]
	public string? PmsCode { get; set; }

	/// <summary>
	/// Gets or sets the set of rate plans.
	/// </summary>
	[JsonPropertyName("ratePlans")]
	public RatePlan?[]? RatePlans { get; set; }

	/// <summary>
	/// Gets or sets the room ID.
	/// </summary>
	[JsonPropertyName("id")]
	public int RoomId { get; set; }

	/// <summary>
	/// Gets or sets the room settings.
	/// </summary>
	[JsonPropertyName("settings")]
	public PropertyRoomSettings? Settings { get; set; }

	/// <summary>
	/// Gets or sets the room status.
	/// </summary>
	[JsonPropertyName("status")]
	public string? Status { get; set; }

	/// <summary>
	/// Gets or sets the room type.
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }
}

/// <summary>
/// Represents the property room settings.
/// </summary>
public class PropertyRoomSettings
{
	/// <summary>
	/// Gets or sets the number of adults.
	/// </summary>
	[JsonPropertyName("adultsNumber")]
	public int? Adults { get; set; }

	/// <summary>
	/// Gets or sets the base number of adults.
	/// </summary>
	[JsonPropertyName("baseAdults")]
	public int? BaseAdults { get; set; }

	/// <summary>
	/// Gets or sets the base number of children.
	/// </summary>
	[JsonPropertyName("baseChildren")]
	public int? BaseChildren { get; set; }

	/// <summary>
	/// Gets or sets the base number of infants.
	/// </summary>
	[JsonPropertyName("baseInfants")]
	public int? BaseInfants { get; set; }

	/// <summary>
	/// Gets or sets the number of children.
	/// </summary>
	[JsonPropertyName("childrenNumber")]
	public int? Children { get; set; }

	/// <summary>
	/// Gets or sets the number of infants.
	/// </summary>
	[JsonPropertyName("infantsNumber")]
	public int? Infants { get; set; }

	/// <summary>
	/// Gets or sets the max occupancy.
	/// </summary>
	[JsonPropertyName("maxOccupancy")]
	public int? MaxOccupancy { get; set; }

	/// <summary>
	/// Gets or sets the number of bedrooms.
	/// </summary>
	[JsonPropertyName("numberOfBedrooms")]
	public int? NumberOfBedrooms { get; set; }

	/// <summary>
	/// Gets or sets the number of beds.
	/// </summary>
	[JsonPropertyName("numberOfBeds")]
	public int? NumberOfBeds { get; set; }

	/// <summary>
	/// Gets or sets the room size.
	/// </summary>
	[JsonPropertyName("roomSize")]
	public int? RoomSize { get; set; }

	/// <summary>
	/// Gets or sets the room size in common units.
	/// </summary>
	[JsonPropertyName("size")]
	public PropertyRoomSize? Size { get; set; }
}

/// <summary>
/// Represents the property room size.
/// </summary>
[DebuggerDisplay("{SquareFeet,nq} sqf/{SquareMeters,nq} sqm")]
public struct PropertyRoomSize
{
	/// <summary>
	/// Gets or sets the square feet.
	/// </summary>
	[JsonPropertyName("squareFeet")]
	public int? SquareFeet { get; set; }

	/// <summary>
	/// Gets or sets the square meters.
	/// </summary>
	[JsonPropertyName("squareMeters")]
	public int? SquareMeters { get; set; }	
}
