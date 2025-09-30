// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace HyperGuestSDK.Api.Book;

using System.Text.Json.Serialization;

/// <summary>
/// A wrapper for the booking response from the HyperGuest API.
/// </summary>
public class BookingResponse
{
	/// <summary>
	/// The main content of the booking response.
	/// </summary>
	[JsonPropertyName("content")]
	public Booking? Booking { get; set; }

	/// <summary>
	/// The timestamp when the booking response was generated.
	/// </summary>
	[JsonPropertyName("timestamp")]
	public DateTime? Timestamp { get; set; }
}

/// <summary>
/// Represents the status of a booking.
/// </summary>
public enum BookingStatus
{
	Confirmed,
	Pending,
	Rejected,
	Cancelled,
	Failed,

	Unknown
}

/// <summary>
/// Main content of the booking response, including status, dates, payment, prices, rooms, and more.
/// </summary>
public class Booking
{
	/// <summary>
	/// The current status of the booking (e.g., confirmed, pending).
	/// </summary>
	[JsonPropertyName("status")]
	public string? StatusValue { get; set; }

	/// <summary>
	/// Gets the current booking status, or <see langword="null"/> if the status value is not recognized.
	/// </summary>
	/// <remarks>If the status value cannot be parsed to a valid <see cref="BookingStatus"/>, the property returns
	/// <see cref="BookingStatus.Unknown"/>. The comparison is case-insensitive.</remarks>
	public BookingStatus? Status
		=> Enum.TryParse<BookingStatus>(StatusValue, true, out var status) ? status : BookingStatus.Unknown;

	/// <summary>
	/// The check-in and check-out dates for the stay.
	/// </summary>
	[JsonPropertyName("dates")]
	public Dates? Dates { get; set; }

	/// <summary>
	/// Additional metadata related to the booking.
	/// </summary>
	//[JsonPropertyName("meta")]
	//public object[]? Meta { get; set; }

	/// <summary>
	/// Payment details for the booking.
	/// </summary>
	[JsonPropertyName("payment")]
	public Payment? Payment { get; set; }

	/// <summary>
	/// Pricing details for the booking.
	/// </summary>
	[JsonPropertyName("prices")]
	public Prices? Prices { get; set; }

	/// <summary>
	/// Nightly breakdown of prices and fees.
	/// </summary>
	[JsonPropertyName("nightlyBreakdown")]
	public NightlyBreakdown[]? NightlyBreakdown { get; set; }

	/// <summary>
	/// List of rooms included in the booking.
	/// </summary>
	[JsonPropertyName("rooms")]
	public Room[]? Rooms { get; set; }

	/// <summary>
	/// Unique identifier for the booking.
	/// </summary>
	[JsonPropertyName("bookingId")]
	public int? BookingId { get; set; }

	/// <summary>
	/// Reference information for the booking (e.g., agency).
	/// </summary>
	[JsonPropertyName("reference")]
	public Reference? Reference { get; set; }

	/// <summary>
	/// Details about the lead guest for the booking.
	/// </summary>
	[JsonPropertyName("leadGuest")]
	public Guest? LeadGuest { get; set; }

	/// <summary>
	/// List of transactions related to the booking.
	/// </summary>
	//[JsonPropertyName("transactions")]
	//public object[]? Transactions { get; set; }

	/// <summary>
	/// Identifier for the property being booked.
	/// </summary>
	[JsonPropertyName("propertyId")]
	public int? PropertyId { get; set; }

	/// <summary>
	/// Financial model details for the booking.
	/// </summary>
	[JsonPropertyName("financialModel")]
	public FinancialModel? FinancialModel { get; set; }
}

/// <summary>
/// Represents the check-in and check-out dates for a hotel stay.
/// </summary>
public class Dates
{
	/// <summary>
	/// The start date of the booking.
	/// </summary>
	[JsonPropertyName("from")]
	public DateTime? From { get; set; }

	/// <summary>
	/// The end date of the booking.
	/// </summary>
	[JsonPropertyName("to")]
	public DateTime? To { get; set; }
}

/// <summary>
/// Details about the payment method and amount for the booking.
/// </summary>
public class Payment
{
	/// <summary>
	/// The type of payment (e.g., credit card, PayPal).
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	/// The amount to be charged for the booking.
	/// </summary>
	[JsonPropertyName("chargeAmount")]
	public Chargeamount? ChargeAmount { get; set; }
}

/// <summary>
/// Represents the charge amount and currency for the booking payment.
/// </summary>
public class Chargeamount
{
	/// <summary>
	/// The price of the booking.
	/// </summary>
	[JsonPropertyName("price")]
	public int? Price { get; set; }

	/// <summary>
	/// The currency of the payment.
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }
}

/// <summary>
/// Pricing details for the booking, including net, sell, commission, bar, and fees.
/// </summary>
public class Prices
{
	/// <summary>
	/// The net price of the booking (excluding taxes and fees).
	/// </summary>
	[JsonPropertyName("net")]
	public Net? Net { get; set; }

	/// <summary>
	/// The selling price of the booking (including all taxes and fees).
	/// </summary>
	[JsonPropertyName("sell")]
	public Sell? Sell { get; set; }

	/// <summary>
	/// The commission amount for the booking.
	/// </summary>
	[JsonPropertyName("commission")]
	public Commission? Commission { get; set; }

	/// <summary>
	/// The base price before any discounts or markups.
	/// </summary>
	[JsonPropertyName("bar")]
	public Bar? Bar { get; set; }

	/// <summary>
	/// Any additional fees associated with the booking.
	/// </summary>
	[JsonPropertyName("fees")]
	public Fee[]? Fees { get; set; }
}

/// <summary>
/// Net price details, including amount, currency, and taxes.
/// </summary>
public class Net
{
	/// <summary>
	/// The net price amount.
	/// </summary>
	[JsonPropertyName("price")]
	public int? Price { get; set; }

	/// <summary>
	/// The currency of the net price.
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// List of taxes applied to the net price.
	/// </summary>
	[JsonPropertyName("taxes")]
	public Tax[]? Taxes { get; set; }
}

/// <summary>
/// Selling price details, including amount, currency, and taxes.
/// </summary>
public class Sell
{
	/// <summary>
	/// The selling price amount.
	/// </summary>
	[JsonPropertyName("price")]
	public float? Price { get; set; }

	/// <summary>
	/// The currency of the selling price.
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// List of taxes applied to the selling price.
	/// </summary>
	[JsonPropertyName("taxes")]
	public Tax[]? Taxes { get; set; }
}

/// <summary>
/// Commission details for the booking.
/// </summary>
public class Commission
{
	/// <summary>
	/// The commission price amount.
	/// </summary>
	[JsonPropertyName("price")]
	public int? Price { get; set; }

	/// <summary>
	/// The currency of the commission price.
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }
}

/// <summary>
/// Base price (bar) details for the booking.
/// </summary>
public class Bar
{
	/// <summary>
	/// The bar price amount.
	/// </summary>
	[JsonPropertyName("price")]
	public float? Price { get; set; }

	/// <summary>
	/// The currency of the bar price.
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }
}

/// <summary>
/// Represents a fee associated with the booking, such as cleaning or service fees.
/// </summary>
public class Fee
{
	/// <summary>
	/// Description of the fee (e.g., cleaning fee, service fee).
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// The amount of the fee.
	/// </summary>
	[JsonPropertyName("amount")]
	public float? Amount { get; set; }

	/// <summary>
	/// The currency of the fee amount.
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// The relation of the fee to the booking (e.g., mandatory, optional).
	/// </summary>
	[JsonPropertyName("relation")]
	public string? Relation { get; set; }

	/// <summary>
	/// The scope of the fee (e.g., one-time, per night).
	/// </summary>
	[JsonPropertyName("scope")]
	public string? Scope { get; set; }

	/// <summary>
	/// The frequency at which the fee is charged (e.g., once, nightly).
	/// </summary>
	[JsonPropertyName("frequency")]
	public string? Frequency { get; set; }
}

/// <summary>
/// Reference information for the booking, such as agency reference.
/// </summary>
public class Reference
{
	/// <summary>
	/// The agency reference for the booking.
	/// </summary>
	[JsonPropertyName("agency")]
	public string? Agency { get; set; }
}

/// <summary>
/// Name details for a guest, including first and last name.
/// </summary>
public class Name
{
	/// <summary>
	/// The first name of the guest.
	/// </summary>
	[JsonPropertyName("first")]
	public string? First { get; set; }

	/// <summary>
	/// The last name of the guest.
	/// </summary>
	[JsonPropertyName("last")]
	public string? Last { get; set; }
}

/// <summary>
/// Contact information for a guest, including address, email, and phone.
/// </summary>
public class Contact
{
	/// <summary>
	/// The address of the guest.
	/// </summary>
	[JsonPropertyName("address")]
	public string? Address { get; set; }

	/// <summary>
	/// The city where the guest resides.
	/// </summary>
	[JsonPropertyName("city")]
	public string? City { get; set; }

	/// <summary>
	/// The country where the guest resides.
	/// </summary>
	[JsonPropertyName("country")]
	public string? Country { get; set; }

	/// <summary>
	/// The nationality of the guest.
	/// </summary>
	[JsonPropertyName("nationality")]
	public string? Nationality { get; set; }

	/// <summary>
	/// The email address of the guest.
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary>
	/// The phone number of the guest.
	/// </summary>
	[JsonPropertyName("phone")]
	public string? Phone { get; set; }

	/// <summary>
	/// The state where the guest resides.
	/// </summary>
	[JsonPropertyName("state")]
	public string? State { get; set; }

	/// <summary>
	/// The ZIP or postal code of the guest's address.
	/// </summary>
	[JsonPropertyName("zip")]
	public string? Zip { get; set; }
}

/// <summary>
/// Financial model details for the booking, including type, keys, comments, and model name.
/// </summary>
public class FinancialModel
{
	/// <summary>
	/// The type of financial model applied to the booking.
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	/// List of key-value pairs representing financial attributes.
	/// </summary>
	[JsonPropertyName("keys")]
	public Key[]? Keys { get; set; }

	/// <summary>
	/// List of comments or notes related to the financial model.
	/// </summary>
	[JsonPropertyName("comments")]
	public Comment[]? Comments { get; set; }

	/// <summary>
	/// The specific model of the financial arrangement.
	/// </summary>
	[JsonPropertyName("model")]
	public string? Model { get; set; }
}

/// <summary>
/// Key-value pair representing a financial attribute in the financial model.
/// </summary>
public class Key
{
	/// <summary>
	/// The price associated with the key.
	/// </summary>
	[JsonPropertyName("price")]
	public Price? Price { get; set; }

	/// <summary>
	/// The key identifier.
	/// </summary>
	[JsonPropertyName("key")]
	public string? KeyValue { get; set; }

	/// <summary>
	/// The value or data associated with the key.
	/// </summary>
	[JsonPropertyName("value")]
	public string? ValueData { get; set; }

	/// <summary>
	/// The order of the key in the financial model.
	/// </summary>
	[JsonPropertyName("order")]
	public int? Order { get; set; }

	/// <summary>
	/// Indicates if the key is highlighted in the display.
	/// </summary>
	[JsonPropertyName("highlight")]
	public bool? Highlight { get; set; }

	/// <summary>
	/// The calculation method for the key's value.
	/// </summary>
	[JsonPropertyName("calculation")]
	public Calculation? Calculation { get; set; }

	/// <summary>
	/// Tags associated with the key for categorization.
	/// </summary>
	[JsonPropertyName("tags")]
	public string[]? Tags { get; set; }

	/// <summary>
	/// Description of the key's purpose or details.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }
}

/// <summary>
/// Price details for a financial key, including amount and currency.
/// </summary>
public class Price
{
	/// <summary>
	/// The amount of money for the price.
	/// </summary>
	[JsonPropertyName("amount")]
	public float? Amount { get; set; }

	/// <summary>
	/// The currency of the price amount.
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }
}

/// <summary>
/// Calculation method for a financial key, including type, relation, and value.
/// </summary>
public class Calculation
{
	/// <summary>
	/// The type of calculation to be performed (e.g., fixed, percentage).
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	/// The relation of the calculation to other values (e.g., additive, multiplicative).
	/// </summary>
	[JsonPropertyName("relation")]
	public string? Relation { get; set; }

	/// <summary>
	/// The value used in the calculation.
	/// </summary>
	[JsonPropertyName("value")]
	public Value? Value { get; set; }
}

/// <summary>
/// Value used in a calculation, including type, value, and currency.
/// </summary>
public class Value
{
	/// <summary>
	/// The data type of the value (e.g., integer, decimal).
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	/// The actual value data.
	/// </summary>
	[JsonPropertyName("value")]
	public int? ValueData { get; set; }

	/// <summary>
	/// The currency of the value, if applicable.
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }
}

/// <summary>
/// Comment or note related to the financial model.
/// </summary>
public class Comment
{
	/// <summary>
	/// The price associated with the comment.
	/// </summary>
	[JsonPropertyName("price")]
	public Price? Price { get; set; }

	/// <summary>
	/// The key identifier for the comment.
	/// </summary>
	[JsonPropertyName("key")]
	public string? Key { get; set; }

	/// <summary>
	/// The order of the comment in the list.
	/// </summary>
	[JsonPropertyName("order")]
	public int? Order { get; set; }

	/// <summary>
	/// The value or text of the comment.
	/// </summary>
	[JsonPropertyName("value")]
	public string? Value { get; set; }

	/// <summary>
	/// Indicates if the comment is highlighted.
	/// </summary>
	[JsonPropertyName("highlight")]
	public bool? Highlight { get; set; }

	/// <summary>
	/// The calculation method for the comment's value.
	/// </summary>
	[JsonPropertyName("calculation")]
	public Calculation? Calculation { get; set; }

	/// <summary>
	/// Tags associated with the comment for categorization.
	/// </summary>
	[JsonPropertyName("tags")]
	public string[]? Tags { get; set; }

	/// <summary>
	/// Description of the comment's purpose or details.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }
}

/// <summary>
/// Nightly breakdown of prices and fees for the booking.
/// </summary>
public class NightlyBreakdown
{
	/// <summary>
	/// The date of the nightly breakdown.
	/// </summary>
	[JsonPropertyName("date")]
	public string? Date { get; set; }

	/// <summary>
	/// The prices applicable for the night.
	/// </summary>
	[JsonPropertyName("prices")]
	public NightlyPrices? Prices { get; set; }
}

/// <summary>
/// Prices applicable for a specific night in the booking.
/// </summary>
public class NightlyPrices
{
	/// <summary>
	/// List of fees applicable for the night.
	/// </summary>
	[JsonPropertyName("fees")]
	public Fee[]? Fees { get; set; }

	/// <summary>
	/// The net price for the night (excluding taxes and fees).
	/// </summary>
	[JsonPropertyName("net")]
	public Net? Net { get; set; }

	/// <summary>
	/// The selling price for the night (including all taxes and fees).
	/// </summary>
	[JsonPropertyName("sell")]
	public Sell? Sell { get; set; }

	/// <summary>
	/// The commission amount for the night.
	/// </summary>
	[JsonPropertyName("commission")]
	public Commission1? Commission { get; set; }

	/// <summary>
	/// The base price for the night before any discounts or markups.
	/// </summary>
	[JsonPropertyName("bar")]
	public Bar? Bar { get; set; }
}

/// <summary>
/// Commission details for a specific night.
/// </summary>
public class Commission1
{
	/// <summary>
	/// The commission price amount for the night.
	/// </summary>
	[JsonPropertyName("price")]
	public int? Price { get; set; }

	/// <summary>
	/// The currency of the commission price for the night.
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }
}

/// <summary>
/// Details about a room included in the booking, including guests, prices, and policies.
/// </summary>
public class Room
{
	/// <summary>
	/// Cancellation policies associated with the room.
	/// </summary>
	[JsonPropertyName("cancellationPolicy")]
	public CancellationPolicy[]? CancellationPolicy { get; set; }

	/// <summary>
	/// List of guests occupying the room.
	/// </summary>
	[JsonPropertyName("guests")]
	public Guest[]? Guests { get; set; }

	/// <summary>
	/// Special requests made for the room.
	/// </summary>
	//[JsonPropertyName("specialRequests")]
	//public object[]? SpecialRequests { get; set; }

	/// <summary>
	/// Remarks or notes about the room.
	/// </summary>
	[JsonPropertyName("remarks")]
	public string[]? Remarks { get; set; }

	/// <summary>
	/// Reference information for the room.
	/// </summary>
	[JsonPropertyName("reference")]
	public Reference? Reference { get; set; }

	/// <summary>
	/// Unique identifier for the room item.
	/// </summary>
	[JsonPropertyName("itemId")]
	public int? ItemId { get; set; }

	/// <summary>
	/// Unique identifier for the room.
	/// </summary>
	[JsonPropertyName("roomId")]
	public int? RoomId { get; set; }

	/// <summary>
	/// Identifier for the rate plan associated with the room.
	/// </summary>
	[JsonPropertyName("ratePlanId")]
	public int? RatePlanId { get; set; }

	/// <summary>
	/// The code representing the room type.
	/// </summary>
	[JsonPropertyName("roomCode")]
	public string? RoomCode { get; set; }

	/// <summary>
	/// The name of the room type.
	/// </summary>
	[JsonPropertyName("roomName")]
	public string? RoomName { get; set; }

	/// <summary>
	/// The code representing the rate plan.
	/// </summary>
	[JsonPropertyName("rateCode")]
	public string? RateCode { get; set; }

	/// <summary>
	/// The name of the rate plan.
	/// </summary>
	[JsonPropertyName("ratePlanName")]
	public string? RatePlanName { get; set; }

	/// <summary>
	/// The current status of the room (e.g., available, booked).
	/// </summary>
	[JsonPropertyName("status")]
	public string? Status { get; set; }

	/// <summary>
	/// The board type or meal plan associated with the room.
	/// </summary>
	[JsonPropertyName("board")]
	public string? Board { get; set; }

	/// <summary>
	/// Financial model details for the room.
	/// </summary>
	[JsonPropertyName("financialModel")]
	public FinancialModel? FinancialModel { get; set; }

	/// <summary>
	/// Identifier for the property to which the room belongs.
	/// </summary>
	[JsonPropertyName("propertyId")]
	public int? PropertyId { get; set; }

	/// <summary>
	/// Pricing details for the room.
	/// </summary>
	[JsonPropertyName("prices")]
	public RoomPrices? Prices { get; set; }

	/// <summary>
	/// Payment details for the room.
	/// </summary>
	[JsonPropertyName("payment")]
	public Payment? Payment { get; set; }

	/// <summary>
	/// Nightly breakdown of prices and fees for the room.
	/// </summary>
	[JsonPropertyName("nightlyBreakdown")]
	public NightlyBreakdownRoom[]? NightlyBreakdown { get; set; }
}

/// <summary>
/// Key-value pair representing a financial attribute for a room.
/// </summary>
public class KeyRoom
{
	/// <summary>
	/// The price associated with the key for the room.
	/// </summary>
	[JsonPropertyName("price")]
	public PriceRoom? Price { get; set; }

	/// <summary>
	/// The key identifier for the room attribute.
	/// </summary>
	[JsonPropertyName("key")]
	public string? Key { get; set; }

	/// <summary>
	/// The value or data associated with the room attribute.
	/// </summary>
	[JsonPropertyName("value")]
	public string? Value { get; set; }

	/// <summary>
	/// The order of the key in the financial model for the room.
	/// </summary>
	[JsonPropertyName("order")]
	public int? Order { get; set; }

	/// <summary>
	/// Indicates if the key is highlighted in the display for the room.
	/// </summary>
	[JsonPropertyName("highlight")]
	public bool? Highlight { get; set; }

	/// <summary>
	/// The calculation method for the key's value for the room.
	/// </summary>
	[JsonPropertyName("calculation")]
	public CalculationRoom? Calculation { get; set; }

	/// <summary>
	/// Tags associated with the key for categorization for the room.
	/// </summary>
	[JsonPropertyName("tags")]
	public string[]? Tags { get; set; }

	/// <summary>
	/// Description of the key's purpose or details for the room.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }
}

/// <summary>
/// Price details for a room financial key, including amount and currency.
/// </summary>
public class PriceRoom
{
	/// <summary>
	/// The amount of money for the price.
	/// </summary>
	[JsonPropertyName("amount")]
	public float? Amount { get; set; }

	/// <summary>
	/// The currency of the price amount.
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }
}

/// <summary>
/// Calculation method for a room financial key, including type, relation, and value.
/// </summary>
public class CalculationRoom
{
	/// <summary>
	/// The type of calculation to be performed (e.g., fixed, percentage).
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	/// The relation of the calculation to other values (e.g., additive, multiplicative).
	/// </summary>
	[JsonPropertyName("relation")]
	public string? Relation { get; set; }

	/// <summary>
	/// The value used in the calculation.
	/// </summary>
	[JsonPropertyName("value")]
	public ValueRoom? Value { get; set; }
}

/// <summary>
/// Value used in a room financial key calculation, including type, value, and currency.
/// </summary>
public class ValueRoom
{
	/// <summary>
	/// The data type of the value (e.g., integer, decimal).
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	/// The actual value data.
	/// </summary>
	[JsonPropertyName("value")]
	public int? Value { get; set; }

	/// <summary>
	/// The currency of the value, if applicable.
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }
}

/// <summary>
/// Comment or note related to a room's financial model.
/// </summary>
public class CommentRoom
{
	/// <summary>
	/// The price associated with the comment.
	/// </summary>
	[JsonPropertyName("price")]
	public PriceRoomComment? Price { get; set; }

	/// <summary>
	/// The key identifier for the comment.
	/// </summary>
	[JsonPropertyName("key")]
	public string? Key { get; set; }

	/// <summary>
	/// The order of the comment in the list.
	/// </summary>
	[JsonPropertyName("order")]
	public int? Order { get; set; }

	/// <summary>
	/// The value or text of the comment.
	/// </summary>
	[JsonPropertyName("value")]
	public string? Value { get; set; }

	/// <summary>
	/// Indicates if the comment is highlighted.
	/// </summary>
	[JsonPropertyName("highlight")]
	public bool? Highlight { get; set; }

	/// <summary>
	/// The calculation method for the comment's value.
	/// </summary>
	[JsonPropertyName("calculation")]
	public CalculationRoomComment? Calculation { get; set; }

	/// <summary>
	/// Tags associated with the comment for categorization.
	/// </summary>
	[JsonPropertyName("tags")]
	public string[]? Tags { get; set; }

	/// <summary>
	/// Description of the comment's purpose or details.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }
}

/// <summary>
/// Price details for a room comment, including amount and currency.
/// </summary>
public class PriceRoomComment
{
	/// <summary>
	/// The amount of money for the price.
	/// </summary>
	[JsonPropertyName("amount")]
	public float? Amount { get; set; }

	/// <summary>
	/// The currency of the price amount.
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }
}

/// <summary>
/// Calculation method for a room comment, including type, relation, and value.
/// </summary>
public class CalculationRoomComment
{
	/// <summary>
	/// The type of calculation to be performed (e.g., fixed, percentage).
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	/// The relation of the calculation to other values (e.g., additive, multiplicative).
	/// </summary>
	[JsonPropertyName("relation")]
	public string? Relation { get; set; }

	/// <summary>
	/// The value used in the calculation.
	/// </summary>
	[JsonPropertyName("value")]
	public ValueRoomComment? Value { get; set; }
}

/// <summary>
/// Value used in a room comment calculation, including type and value.
/// </summary>
public class ValueRoomComment
{
	/// <summary>
	/// The data type of the value (e.g., integer, decimal).
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	/// The actual value data.
	/// </summary>
	[JsonPropertyName("value")]
	public int? Value { get; set; }
}

/// <summary>
/// Nightly breakdown of prices and fees for a specific room.
/// </summary>
public class NightlyBreakdownRoom
{
	/// <summary>
	/// The date of the nightly breakdown.
	/// </summary>
	[JsonPropertyName("date")]
	public string? Date { get; set; }

	/// <summary>
	/// The prices applicable for the night.
	/// </summary>
	[JsonPropertyName("prices")]
	public NightlyRoomPrices? Prices { get; set; }
}

/// <summary>
/// Prices applicable for a specific night in a room.
/// </summary>
public class NightlyRoomPrices
{
	/// <summary>
	/// The net price for the night (excluding taxes and fees).
	/// </summary>
	[JsonPropertyName("net")]
	public Net? Net { get; set; }

	/// <summary>
	/// The selling price for the night (including all taxes and fees).
	/// </summary>
	[JsonPropertyName("sell")]
	public Sell? Sell { get; set; }

	/// <summary>
	/// The commission amount for the night.
	/// </summary>
	[JsonPropertyName("commission")]
	public Commission? Commission { get; set; }

	/// <summary>
	/// The base price for the night before any discounts or markups.
	/// </summary>
	[JsonPropertyName("bar")]
	public Bar? Bar { get; set; }

	/// <summary>
	/// List of fees applicable for the night.
	/// </summary>
	[JsonPropertyName("fees")]
	public Fee[]? Fees { get; set; }
}

/// <summary>
/// Cancellation policy details for a room, including policy ID, dates, and price.
/// </summary>
public class CancellationPolicy
{
	/// <summary>
	/// Unique identifier for the cancellation policy.
	/// </summary>
	[JsonPropertyName("policyId")]
	public int? PolicyId { get; set; }

	/// <summary>
	/// The start date of the cancellation policy.
	/// </summary>
	[JsonPropertyName("startDate")]
	public string? StartDate { get; set; }

	/// <summary>
	/// The end date of the cancellation policy.
	/// </summary>
	[JsonPropertyName("endDate")]
	public string? EndDate { get; set; }

	/// <summary>
	/// Price details related to the cancellation policy.
	/// </summary>
	[JsonPropertyName("price")]
	public Price? Price { get; set; }
}

/// <summary>
/// Details about a guest occupying a room, including name, contact, and age.
/// </summary>
public class Guest
{
	/// <summary>
	/// Unique identifier for the guest.
	/// </summary>
	[JsonPropertyName("guestId")]
	public int? GuestId { get; set; }

	/// <summary>
	/// The birth date of the guest.
	/// </summary>
	[JsonPropertyName("birthDate")]
	public string? BirthDate { get; set; }

	/// <summary>
	/// The name of the guest.
	/// </summary>
	[JsonPropertyName("name")]
	public Name? Name { get; set; }

	/// <summary>
	/// The contact information of the guest.
	/// </summary>
	[JsonPropertyName("contact")]
	public Contact? Contact { get; set; }

	/// <summary>
	/// The title of the guest (e.g., Mr, Mrs, Dr).
	/// </summary>
	[JsonPropertyName("title")]
	public string? Title { get; set; }

	/// <summary>
	/// The age of the guest.
	/// </summary>
	[JsonPropertyName("age")]
	public int? Age { get; set; }
}

/// <summary>
/// Tax details applied to booking or room prices.
/// </summary>
public class Tax
{
	/// <summary>
	/// Description of the tax (e.g., VAT, service tax).
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// The amount of the tax.
	/// </summary>
	[JsonPropertyName("amount")]
	public float? Amount { get; set; }

	/// <summary>
	/// The currency of the tax amount.
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// The relation of the tax to the booking (e.g., inclusive, exclusive).
	/// </summary>
	[JsonPropertyName("relation")]
	public string? Relation { get; set; }

	/// <summary>
	/// The scope of the tax (e.g., local, state, federal).
	/// </summary>
	[JsonPropertyName("scope")]
	public string? Scope { get; set; }

	/// <summary>
	/// The frequency at which the tax is applied (e.g., once, recurring).
	/// </summary>
	[JsonPropertyName("frequency")]
	public string? Frequency { get; set; }
}

/// <summary>
/// Pricing details for a room, including net, sell, commission, bar, and fees.
/// </summary>
public class RoomPrices
{
	/// <summary>
	/// The net price of the room (excluding taxes and fees).
	/// </summary>
	[JsonPropertyName("net")]
	public Net? Net { get; set; }

	/// <summary>
	/// The selling price of the room (including all taxes and fees).
	/// </summary>
	[JsonPropertyName("sell")]
	public Sell? Sell { get; set; }

	/// <summary>
	/// The commission amount for the room.
	/// </summary>
	[JsonPropertyName("commission")]
	public Commission? Commission { get; set; }

	/// <summary>
	/// The base price of the room before any discounts or markups.
	/// </summary>
	[JsonPropertyName("bar")]
	public Bar? Bar { get; set; }

	/// <summary>
	/// Any additional fees associated with the room.
	/// </summary>
	//[JsonPropertyName("fees")]
	//public object[]? Fees { get; set; }
}
