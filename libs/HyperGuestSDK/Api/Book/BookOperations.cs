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
	Task<HyperGuestResponse<BookingResponse>> CreateAsync(
		BookRequest request,
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
}
