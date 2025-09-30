// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace HyperGuestSDK.Api.Book;

using System.Text.Json.Serialization;

/// <summary>
/// Represents a request to book a stay.
/// </summary>
public class BookRequest : Model<BookRequest>
{
	/// <summary>
	/// Gets or sets the from and to dates for this booking.
	/// </summary>
	[JsonPropertyName("dates"), JsonPropertyOrder(0)]
	public BookingDates Dates { get; set; }

	/// <summary>
	/// Gets or sets the details of the lead guest associated with the booking.
	/// </summary>
	[JsonPropertyName("leadGuest"), JsonPropertyOrder(2)]
	public GuestDetails? LeadGuest { get; set; }

	/// <summary>
	/// Gets or sets the collection of metadata key-value pairs associated with this instance.
	/// </summary>
	/// <remarks>Keys are case-sensitive. Values may be null to indicate the absence of a value for a given key. The
	/// dictionary itself may be null if no metadata is associated.</remarks>
	[JsonPropertyName("meta"), JsonPropertyOrder(6)]
	public Dictionary<string, string?>? Metadata { get; set; }

	/// <summary>
	/// Gets or sets the payment details associated with the transaction.
	/// </summary>
	[JsonPropertyName("paymentDetails"), JsonPropertyOrder(4)]
	public PaymentDetails? Payment { get; set; }

	/// <summary>
	/// Gets or sets the property ID to book.
	/// </summary>
	[JsonPropertyName("propertyId"), JsonPropertyOrder(1)]
	public int PropertyId { get; set; }

	/// <summary>
	/// Gets or sets the reference details associated with this instance.
	/// </summary>
	[JsonPropertyName("reference"), JsonPropertyOrder(3)]
	public ReferenceDetails? Reference { get; set; }

	/// <summary>
	/// Gets or sets the collection of room details associated with this instance.
	/// </summary>
	[JsonPropertyName("rooms"), JsonPropertyOrder(5)]
	public List<RoomDetails>? Rooms { get; set; }
}

/// <summary>
/// Represents a range of dates for a booking, including the start and end dates.
/// </summary>
/// <param name="From">The start date of the booking period. Represents the inclusive beginning of the date range.</param>
/// <param name="To">The end date of the booking period. Represents the inclusive end of the date range.</param>
public record BookingDates(
	[property: JsonPropertyName("from"), JsonConverter(typeof(DateOnlyJsonConverter))] DateTime From,
	[property: JsonPropertyName("to"), JsonConverter(typeof(DateOnlyJsonConverter))] DateTime To
);

/// <summary>
/// Represents the personal and contact details of a guest, including name, title, date of birth, and contact
/// information.
/// </summary>
public class GuestDetails
{
	/// <summary>
	/// Gets or sets the date of birth.
	/// </summary>
	[JsonPropertyName("birthDate"), JsonPropertyOrder(0)]
	public DateTime BirthDate { get; set; }

	/// <summary>
	/// Gets or sets the contact information associated with this entity.
	/// </summary>
	[JsonPropertyName("contact"), JsonPropertyOrder(1)]
	public ContactDetails? Contact { get; set; }

	/// <summary>
	/// Gets or sets the name details associated with the entity.
	/// </summary>
	[JsonPropertyName("name"), JsonPropertyOrder(2)]
	public NameDetails? Name { get; set; }

	/// <summary>
	/// Gets or sets the title associated with the object.
	/// </summary>
	[JsonPropertyName("title"), JsonPropertyOrder(3)]
	public string? Title { get; set; }
}

/// <summary>
/// Represents a set of contact information, including address, phone number, and email details.
/// </summary>
/// <remarks>Use this class to store or transfer contact details for an individual or organization. All properties
/// are optional and may be left unset if the corresponding information is not available.</remarks>
public class ContactDetails
{
	/// <summary>
	/// Gets or sets the address associated with the entity.
	/// </summary>
	[JsonPropertyName("address"), JsonPropertyOrder(0)]
	public string? Address { get; set; }

	/// <summary>
	/// Gets or sets the city associated with the entity.
	/// </summary>
	[JsonPropertyName("city"), JsonPropertyOrder(1)]
	public string? City { get; set; }

	/// <summary>
	/// Gets or sets the country associated with the entity.
	/// </summary>
	[JsonPropertyName("country"), JsonPropertyOrder(2)]
	public string? Country { get; set; }

	/// <summary>
	/// Gets or sets the email address associated with the user.
	/// </summary>
	[JsonPropertyName("email"), JsonPropertyOrder(3)]
	public string? Email { get; set; }

	/// <summary>
	/// Gets or sets the phone number associated with the contact.
	/// </summary>
	[JsonPropertyName("phone"), JsonPropertyOrder(4)]
	public string? Phone { get; set; }

	/// <summary>
	/// Gets or sets the state or province associated with the entity.
	/// </summary>
	[JsonPropertyName("state"), JsonPropertyOrder(5)]
	public string? State { get; set; }

	/// <summary>
	/// Gets or sets the postal code associated with the address.
	/// </summary>
	[JsonPropertyName("zip"), JsonPropertyOrder(6)]
	public string? Zip { get; set; }
}

/// <summary>
/// Represents a person's name, including first and last name components.
/// </summary>
public class NameDetails
{   /// <summary>
		/// Gets or sets the first name.
		/// </summary>
	[JsonPropertyName("first"), JsonPropertyOrder(0)]
	public string? First { get; set; }

	/// <summary>
	/// Gets or sets the last name.
	/// </summary>
	[JsonPropertyName("last"), JsonPropertyOrder(1)]
	public string? Last { get; set; }
}

/// <summary>
/// Represents details about a reference, including agency information.
/// </summary>
public class ReferenceDetails
{
	/// <summary>
	/// Gets or sets the agency details
	/// </summary>
	[JsonPropertyName("agency"), JsonPropertyOrder(0)]
	public string? Agency { get; set; }
}

/// <summary>
/// Represents information about a payment, including its type and associated details.
/// </summary>
public class PaymentDetails
{
	/// <summary>
	/// Gets or sets additional details about the payment type.
	/// </summary>
	[JsonPropertyName("details"), JsonPropertyOrder(1)]
	public PaymentTypeDetails? Details { get; set; }

	/// <summary>
	/// Gets or sets the payment type.
	/// </summary>
	[JsonPropertyName("type"), JsonPropertyOrder(0)]
	public string? Type { get; set; }
}

/// <summary>
/// Represents details about a specific payment type.
/// </summary>
[JsonDerivedType(typeof(CardPaymentDetails))]
public abstract class PaymentTypeDetails
{

}

/// <summary>
/// Defines the potential payment types.
/// </summary>
public static class PaymentType
{
	/// <summary>
	/// The payment type is a card payment.
	/// </summary>
	public const string Card = "credit_card";

	/// <summary>
	/// The payment type is an external payment.
	/// </summary>
	public const string External = "external";
}

/// <summary>
/// Represents the details required to process a card payment, including card number, expiration, cardholder name, and
/// CVV.
/// </summary>
/// <remarks>Use this class to provide card-specific information when initiating a payment. All properties should
/// be populated with valid card data as required by the payment processor. Sensitive information such as card number
/// and CVV should be handled securely and in compliance with applicable data protection standards.</remarks>
public class CardPaymentDetails : PaymentTypeDetails
{
	/// <summary>
	/// Gets or sets a value indicating whether a charge should be applied.
	/// </summary>
	[JsonPropertyName("charge"), JsonPropertyOrder(4)]
	public bool Charge { get; set; }

	/// <summary>
	/// Gets or sets the card's CVV (Card Verification Value).
	/// </summary>
	[JsonPropertyName("cvv"), JsonPropertyOrder(1)]
	public string? Cvv { get; set; }

	/// <summary>
	/// Gets or sets the card's expiration details.
	/// </summary>
	[JsonPropertyName("expiry"), JsonPropertyOrder(2)]
	public CardExpiryDetails? Expiry { get; set; }

	/// <summary>
	/// Gets or sets the name on the card.
	/// </summary>
	[JsonPropertyName("name"), JsonPropertyOrder(3)]
	public NameDetails? Name { get; set; }

	/// <summary>
	/// Gets or sets the card number.
	/// </summary>
	[JsonPropertyName("number"), JsonPropertyOrder(0)]
	public string? Number { get; set; }
}

/// <summary>
/// Represents details about the expiry of a card.
/// </summary>
public class CardExpiryDetails
{
	/// <summary>
	/// Gets or sets the card expiry month.
	/// </summary>
	[JsonPropertyName("month"), JsonPropertyOrder(0)]
	public int Month { get; set; }

	/// <summary>
	/// Gets or sets the card expiry year.
	/// </summary>
	[JsonPropertyName("year"), JsonPropertyOrder(1)]
	public int Year { get; set; }
}

/// <summary>
/// Represents the details of a room, including pricing and identification information, for use in transactions.
/// </summary>
public class RoomDetails
{
	/// <summary>
	/// Gets or sets the expected price details for the transaction.
	/// </summary>
	[JsonPropertyName("expectedPrice"), JsonPropertyOrder(2)]
	public PriceDetails? ExpectedPrice { get; set; }

	/// <summary>
	/// Gets or sets the collection of guest details associated with the current entity.
	/// </summary>
	[JsonPropertyName("guests"), JsonPropertyOrder(3)]
	public GuestDetails[]? Guests { get; set; }

	/// <summary>
	/// Gets or sets the rate code associated with this entity.
	/// </summary>
	[JsonPropertyName("rateCode"), JsonPropertyOrder(1)]
	public string? RateCode { get; set; }

	/// <summary>
	/// Gets or sets the unique code that identifies the room.
	/// </summary>
	[JsonPropertyName("roomCode"), JsonPropertyOrder(0)]
	public string? RoomCode { get; set; }

	/// <summary>
	/// Gets or sets the unique identifier of the room. If this value is provided <see cref="RoomCode"/> is ignored.
	/// </summary>
	[JsonPropertyName("roomId"), JsonPropertyOrder(0)]
	public int? RoomId { get; set; }

	/// <summary>
	/// Gets or sets the list of special requests associated with the booking.
	/// </summary>
	[JsonPropertyName("specialRequests"), JsonPropertyOrder(4)]
	public List<string>? SpecialRequests { get; set; }
}

/// <summary>
/// Represents pricing information, including the total amount and its associated currency.
/// </summary>
public class PriceDetails
{
	/// <summary>
	/// Gets or sets the total amount.
	/// </summary>
	[JsonPropertyName("amount"), JsonPropertyOrder(0)]
	public decimal Amount { get; set; }

	/// <summary>
	/// Gets or sets the currency associated with the price.
	/// </summary>
	[JsonPropertyName("currency"), JsonPropertyOrder(1)]
	public string? Currency { get; set; }
}
