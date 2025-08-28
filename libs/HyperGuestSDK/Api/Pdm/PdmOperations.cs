// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace HyperGuestSDK.Api;

partial interface IHyperGuestApiClient
{
}

partial class HyperGuestApiClient
{
	Lazy<IPdmOperations>? _pdm;
	public IPdmOperations Pdm => (_pdm ??= Defer<IPdmOperations>(
		c => new PdmOperations(c))).Value;
}

public partial interface IPdmOperations
{

}

/// <summary>
/// Provides operations for operating on the PDM domain.
/// </summary>
/// <param name="client">The API client.</param>
public partial class PdmOperations(ApiClient client) : IPdmOperations
{
	readonly ApiClient _client = client;
}
