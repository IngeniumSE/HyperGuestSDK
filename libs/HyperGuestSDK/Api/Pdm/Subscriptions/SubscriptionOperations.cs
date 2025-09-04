// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace HyperGuestSDK.Api;

partial interface IPdmOperations
{
	/// <summary>
	/// Gets the subscription operations.
	/// </summary>
	ISubscriptionOperations Subscriptions { get; }
}

partial class PdmOperations
{
	Lazy<ISubscriptionOperations>? _subscriptions;
	public ISubscriptionOperations Subscriptions => (_subscriptions ??= _client.Defer<ISubscriptionOperations>(
		c => new SubscriptionOperations("/api/pdm/subscriptions", c))).Value;
}

public partial interface ISubscriptionOperations
{
	/// <summary>
	/// Initiates the full ARI (Availability, Rates, and Inventory) synchronization process for the specified subscription.
	/// </summary>
	Task<HyperGuestResponse> BeginFullAriSyncProcessAsync(string subscriptionId, CancellationToken cancellationToken = default);

	/// <summary>
	/// Creates a subscription.
	/// </summary>
	/// <param name="request">The subscription request.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The HyperGuest response.</returns>
	Task<HyperGuestResponse<SubscriptionSummary>> CreateSubscriptionAsync(CreateSubscriptionRequest request, CancellationToken cancellationToken = default);

	/// <summary>
	/// Disables the given subscription.
	/// </summary>
	/// <param name="request">The subscription ID.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The HyperGuest response.</returns>
	Task<HyperGuestResponse<SubscriptionSummary>> DisableSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default);

	/// <summary>
	/// Enables the given subscription.
	/// </summary>
	/// <param name="request">The subscription ID.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The HyperGuest response.</returns>
	Task<HyperGuestResponse<SubscriptionSummary>> EnableSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default);

	/// <summary>
	/// Gets the subscription.
	/// </summary>
	/// <param name="subscriptionId">The subscription ID.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The HyperGuest response.</returns>
	Task<HyperGuestResponse<Subscription>> GetSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default);

	/// <summary>
	/// Gets the subscriptions.
	/// </summary>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The HyperGuest response.</returns>
	Task<HyperGuestResponse<Subscription[]>> GetSubscriptionsAsync(CancellationToken cancellationToken = default);
}

public partial class SubscriptionOperations(PathString path, ApiClient client) : ISubscriptionOperations
{
	public async Task<HyperGuestResponse> BeginFullAriSyncProcessAsync(string subscriptionId, CancellationToken cancellationToken = default)
	{
		var request = new HyperGuestRequest(
			HyperGuestService.Pdm,
			HttpMethod.Get,
			path + $"/{subscriptionId}/fullARISync");

		return await client.SendAsync(request, cancellationToken)
			.ConfigureAwait(false);
	}

	public async Task<HyperGuestResponse<SubscriptionSummary>> CreateSubscriptionAsync(CreateSubscriptionRequest rq, CancellationToken cancellationToken = default)
	{
		var request = new HyperGuestRequest<CreateSubscriptionRequest>(
			HyperGuestService.Pdm,
			HttpMethod.Post,
			path + "/subscribe",
			rq);

		return await client.FetchAsync<CreateSubscriptionRequest, SubscriptionSummary>(request, cancellationToken)
			.ConfigureAwait(false);
	}

	public async Task<HyperGuestResponse<SubscriptionSummary>> DisableSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default)
	{
		var request = new HyperGuestRequest(
			HyperGuestService.Pdm,
			HttpMethod.Get,
			path + $"/{subscriptionId}/disableSubscription");

		return await client.FetchAsync<SubscriptionSummary>(request, cancellationToken)
			.ConfigureAwait(false);
	}

	public async Task<HyperGuestResponse<SubscriptionSummary>> EnableSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default)
	{
		var request = new HyperGuestRequest(
			HyperGuestService.Pdm,
			HttpMethod.Get,
			path + $"/{subscriptionId}/enableSubscription");

		return await client.FetchAsync<SubscriptionSummary>(request, cancellationToken)
			.ConfigureAwait(false);
	}

	public async Task<HyperGuestResponse<Subscription>> GetSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default)
	{
		var request = new HyperGuestRequest(
			HyperGuestService.Pdm,
			HttpMethod.Get,
			path + $"/{subscriptionId}/getSubscription");

		return await client.FetchAsync<Subscription>(request, cancellationToken)
			.ConfigureAwait(false);
	}

	public async Task<HyperGuestResponse<Subscription[]>> GetSubscriptionsAsync(CancellationToken cancellationToken = default)
	{
		var request = new HyperGuestRequest(
			HyperGuestService.Pdm,
			HttpMethod.Get,
			path + "/list");

		return await client.FetchAsync<Subscription[]>(request, cancellationToken)
			.ConfigureAwait(false);
	}
}
