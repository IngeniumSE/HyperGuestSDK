// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace HyperGuestSDK.Api.Book;

using System.Text.Json.Serialization;

/// <summary>
/// Represents a request to cancel a book reservation or order.
/// </summary>
public class CancelBookRequest : Model<CancelBookRequest>
{
	/// <summary>
	/// Gets or sets the unique identifier for the booking.
	/// </summary>
	[JsonPropertyName("bookingId")]
	public int BookingId { get; set; }

	/// <summary>
	/// Gets or sets the reason associated with the current operation or status.
	/// </summary>
	[JsonPropertyName("reason")]
	public string Reason { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets a value indicating whether the operation is a simulation, i.e. to return a cancellation price without actually performing the cancellation.
	/// </summary>
	[JsonPropertyName("simulation")]
	public bool Simulation { get; set; }
}
