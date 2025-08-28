// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace HyperGuestSDK;

/// <summary>
/// Represents a request to a Trybe API resource.
/// </summary>
/// <param name="service">The HyperGuest service.</param>
/// <param name="method">The HTTP method.</param>
/// <param name="resource">The relative resource.</param>
/// <param name="query">The query string.</param>
public class HyperGuestRequest(
	HyperGuestService service,
	HttpMethod method,
	PathString resource,
	QueryString? query = null)
{
	readonly HyperGuestService _service = service;
	readonly HttpMethod _method = method;
	readonly PathString _resource = resource;
	readonly QueryString? _query = query;

	/// <summary>
	/// Gets the HTTP method for the request.
	/// </summary>
	public HttpMethod Method => _method;

	/// <summary>
	/// Gets the relative resource for the request.
	/// </summary>
	public PathString Resource => _resource;

	/// <summary>
	/// Gets the query string.
	/// </summary>
	public QueryString? Query => _query;

	/// <summary>
	/// Gets the HyperGuest service.
	/// </summary>
	public HyperGuestService Service => _service;
}

/// <summary>
/// Represents a request to a Trybe API resource.
/// </summary>
/// <param name="service">The HyperGuest service.</param>
/// <param name="method">The HTTP method.</param>
/// <param name="resource">The relative resource.</param>
/// <param name="data">The data.</param>
/// <param name="query">The query string.</param>
/// <typeparam name="TData">The data type.</typeparam>
public class HyperGuestRequest<TData>(
	HyperGuestService service,
	HttpMethod method,
	PathString resource,
	TData data,
	QueryString? query = null) : HyperGuestRequest(service, method, resource, query)
	where TData : notnull
{
	readonly TData _data = data;

	/// <summary>
	/// Gets the model for the request.
	/// </summary>
	public TData Data => _data;
}

/// <summary>
/// Represents the possible HyperGuest services.
/// </summary>
public enum HyperGuestService
{
	/// <summary>
	/// The static data service.
	/// </summary>
	StaticData,

	/// <summary>
	/// The PDM service.
	/// </summary>
	Pdm
}
