// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using HyperGuestSDK.Api;

namespace HyperGuestSDK;

public interface IHyperGuestApiClientFactory
{
	IHyperGuestApiClient CreateApiClient(HyperGuestSettings settings, string? name = null);
}

/// <summary>
/// Provides factory services for creating Trybe client instances.
/// </summary>
public class HyperGuestApiClientFactory : IHyperGuestApiClientFactory
{
	readonly IHyperGuestHttpClientFactory _httpClientFactory;

	public HyperGuestApiClientFactory(IHyperGuestHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = Ensure.IsNotNull(httpClientFactory, nameof(httpClientFactory));
	}

	public IHyperGuestApiClient CreateApiClient(HyperGuestSettings settings, string? name = null)
		=> new HyperGuestApiClient(_httpClientFactory.CreateHttpClient(name), settings);
}
