// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace HyperGuestSDK.Api;

partial interface IHyperGuestApiClient
{
	IStaticOperations Static { get; }
}

partial class HyperGuestApiClient
{
	Lazy<IStaticOperations>? _static;
	public IStaticOperations Static => (_static ??= Defer<IStaticOperations>(
		c => new StaticOperations(c))).Value;
}

public partial interface IStaticOperations
{

}

/// <summary>
/// Provides operations for operating on the PDM domain.
/// </summary>
/// <param name="client">The API client.</param>
public partial class StaticOperations(ApiClient client) : IStaticOperations
{
	readonly ApiClient _client = client;
}
