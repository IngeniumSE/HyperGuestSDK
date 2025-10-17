// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace HyperGuestSDK.Api;

using HyperGuestSDK.Api.Book;

partial interface IHyperGuestApiClient
{
	IBookOperations Book { get; }
}

partial class HyperGuestApiClient
{
	Lazy<IBookOperations>? _book;
	public IBookOperations Book => (_book ??= Defer<IBookOperations>(
		c => new BookOperations("/2.0/booking", c))).Value;
}

public partial interface IBookOperations
{
	/// <summary>
	/// Creates a new booking using the specified booking request.
	/// </summary>
	/// <param name="request">The booking request containing the details required to create the booking. Cannot be null.</param>
	/// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
	/// <returns>A task that represents the asynchronous operation. The task result contains a HyperGuestResponse with the booking
	/// response data.</returns>
	Task<HyperGuestResponse<BookingResponse>> CreateAsync(
		BookRequest request,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Retrieves the booking details for the specified booking identifier.
	/// </summary>
	/// <param name="bookingId">The unique identifier of the booking to retrieve.</param>
	/// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
	/// <returns>A task that represents the asynchronous operation. The task result contains a <see
	/// cref="HyperGuestResponse{BookingResponse}"/> with the booking details if found.</returns>
	Task<HyperGuestResponse<BookingResponse>> GetAsync(
		int bookingId,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Cancels an existing booking request.
	/// </summary>
	/// <param name="request">The details of the booking to cancel. Cannot be null.</param>
	/// <param name="cancellationToken">A token to monitor for cancellation requests. The operation is canceled if the token is triggered.</param>
	/// <returns>A task that represents the asynchronous operation. The task result contains a response with the outcome of the
	/// cancellation request.</returns>
	Task<HyperGuestResponse<BookingResponse>> CancelAsync(
		CancelBookRequest request,
		CancellationToken cancellationToken = default);
}

/// <summary>
/// Provides operations for operating on the Book domain.
/// </summary>
/// <param name="client">The API client.</param>
public partial class BookOperations(PathString path, ApiClient client) : IBookOperations
{
	readonly PathString _path = path;
	readonly ApiClient _client = client;

	public async Task<HyperGuestResponse<BookingResponse>> CancelAsync(
		CancelBookRequest request,
		CancellationToken cancellationToken = default)
	{
		var req = new HyperGuestRequest<CancelBookRequest>(
			HyperGuestService.Book,
			HttpMethod.Post,
			_path + $"/cancel",
			request);

		return await _client.FetchAsync<CancelBookRequest, BookingResponse>(req, cancellationToken)
			.ConfigureAwait(false);
	}

	public async Task<HyperGuestResponse<BookingResponse>> CreateAsync(
		BookRequest request,
		CancellationToken cancellationToken = default)
	{
		var req = new HyperGuestRequest<BookRequest>(
			HyperGuestService.Book,
			HttpMethod.Post,
			_path + $"/create",
			request);

		return await _client.FetchAsync<BookRequest, BookingResponse>(req, cancellationToken)
			.ConfigureAwait(false);
	}

	public async Task<HyperGuestResponse<BookingResponse>> GetAsync(int bookingId, CancellationToken cancellationToken = default)
	{
		var req = new HyperGuestRequest(
			HyperGuestService.Book,
			HttpMethod.Post,
			_path + $"/get/{bookingId}");

		return await _client.FetchAsync<BookingResponse>(req, cancellationToken)
			.ConfigureAwait(false);
	}
}
