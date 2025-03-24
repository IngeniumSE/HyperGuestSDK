// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace HyperGuestSDK.Api;

partial interface IHyperGuestApiClient
{
	/// <summary>
	/// Gets the property operations.
	/// </summary>
	IPropertyOperations Properties { get; }
}

partial class  HyperGuestApiClient
{
	Lazy<IPropertyOperations>? _properties;
	public IPropertyOperations Properties => (_properties ??= Defer<IPropertyOperations>(
		c => new PropertyOperations(c))).Value;
}

/// <summary>
/// Provides operations for operating on the properties endpoint(s)
/// </summary>
public partial interface IPropertyOperations
{
	Task<HyperGuestResponse<Property[]>> GetPropertiesAsync(CancellationToken cancellationToken = default);
}

public partial class PropertyOperations(ApiClient client) : IPropertyOperations
{
	public async Task<HyperGuestResponse<Property[]>> GetPropertiesAsync(CancellationToken cancellationToken = default)
	{
		var path = new PathString("/hotels.json");
		var request = new HyperGuestRequest(HttpMethod.Get, path);

		return await client.FetchAsync<Property[]>(request, cancellationToken);
	}
}
