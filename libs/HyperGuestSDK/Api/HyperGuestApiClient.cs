// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace HyperGuestSDK.Api;

public partial interface IHyperGuestApiClient
{

}

public partial class HyperGuestApiClient : ApiClient, IHyperGuestApiClient
{
	public HyperGuestApiClient(HttpClient http, HyperGuestSettings settings)
		: base(http, settings) { }
}
