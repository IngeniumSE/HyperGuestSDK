// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace HyperGuestSDK.Api;

using System.Text.Json.Serialization;

/// <summary>
/// Represents a subscription.
/// </summary>
public class Subscription
{
	/// <summary>
	/// Gets or sets the envelope.
	/// </summary>
	[JsonPropertyName("envelope")]
	public SubscriptionEnvelope Envelope { get; set; }

	/// <summary>
	/// Gets or sets the method.
	/// </summary>
	[JsonPropertyName("method")]
	public SubscriptionMethod Method { get; set; }

	/// <summary>
	/// Gets or sets the property IDs.
	/// </summary>
	[JsonPropertyName("propertyIds")]
	public required int[] PropertyIds { get; set; }

	/// <summary>
	/// Gets or sets the status.
	/// </summary>
	[JsonPropertyName("status")]
	public SubscriptionStatus Status { get; set; }

	/// <summary>
	/// Gets or sets the status change comment.
	/// </summary>
	[JsonPropertyName("statusChangeComment")]
	public string? StatusChangeComment { get; set; }

	/// <summary>
	/// Gets or sets the subscription ID.
	/// </summary>
	[JsonPropertyName("subscriptionId")]
	public required string SubscriptionId { get; set; }

	/// <summary>
	/// Gets or sets the version.
	/// </summary>
	[JsonPropertyName("version")]
	public int Version { get; set; }
}

/// <summary>
/// Represents a subscription summary.	
/// </summary>
public class SubscriptionSummary
{
	/// <summary>
	/// Gets or sets the status of the subscription.
	/// </summary>
	[JsonPropertyName("status")]
	public SubscriptionStatus Status { get; set; }

	/// <summary>
	/// Gets or sets the subscription ID.
	/// </summary>
	[JsonPropertyName("subscriptionId")]
	public required string SubscriptionId { get; set; }
}

/// <summary>
/// Defines the possible subscription methods.
/// </summary>
public enum SubscriptionMethod
{
	/// <summary>
	/// Availability, Rates and Inventory (ARI)
	/// </summary>
	ARI,

	/// <summary>
	/// Static property metadata.
	/// </summary>
	StaticData
}

/// <summary>
/// Defines the possible subscription envelopes.
/// </summary>
public enum SubscriptionEnvelope
{
	/// <summary>
	/// The HyperGuest data format.
	/// </summary>
	HyperGuest,

	/// <summary>
	/// The OpenTravel Alliance (OTA) data format.
	/// </summary>
	OTA
}

/// <summary>
/// Defines the possible subscription statuses.
/// </summary>
public enum SubscriptionStatus
{
	/// <summary>
	/// The subscription is enabled.
	/// </summary>
	Enabled,

	/// <summary>
	/// The subscription is disabled.
	/// </summary>
	Disabled,

	/// <summary>
	/// The subscription has ended.
	/// </summary>
	Unsubscribed
}

#region Create Requests
/// <summary>
/// Represents a request to create a subscription.
/// </summary>
/// <param name="method">The subscription method (ARI vs StaticData)</param>
/// <param name="propertyIds">The set of property IDs.</param>
/// <param name="envelopeSubUrls">The set of envelop sub-urls (URLs that are called by the subscription).</param>
/// <param name="envelope">The envelope type (HyperGuest vs OTA)</param>
/// <param name="emails">The set of emails used for notification of status changes.</param>
/// <param name="authentication">Any custom authentication values passed to the sub-urls.</param>
/// <param name="version">The version of static-data / ARI</param>
/// <param name="channelMapping">The name of the channel.</param>
public record CreateSubscriptionRequest(
	[property: JsonPropertyName("method")] SubscriptionMethod method,
	[property: JsonPropertyName("propertyIds")] int[] propertyIds,
	[property: JsonPropertyName("envelopeSubUrls")] IDictionary<CallbackUrls, string> envelopeSubUrls,

	
	[property: JsonPropertyName("envelope")] SubscriptionEnvelope envelope = SubscriptionEnvelope.HyperGuest,
	[property: JsonPropertyName("email")] string[]? emails = null,
	[property: JsonPropertyName("authentication")] IDictionary<string, string>? authentication = null,
	[property: JsonPropertyName("version")] int version = 1,
	[property: JsonPropertyName("channelMapping")] string? channelMapping = null
);

/// <summary>
/// Represents a request to create a subscription using the HyperGuest envelope.
/// </summary>
/// <param name="method">The subscription method (ARI vs StaticData)</param>
/// <param name="propertyIds">The set of property IDs.</param>
/// <param name="callbackUrl">The callback URL.</param>
/// <param name="emails">The set of emails used for notification of status changes.</param>
/// <param name="authentication">Any custom authentication values passed to the sub-urls.</param>
/// <param name="version">The version of static-data / ARI</param>
/// <param name="channelMapping">The name of the channel.</param>
public record CreateHyperGuestSubscriptionRequest(
	SubscriptionMethod method,
	int[] propertyIds,
	string callbackUrl,

	string[]? emails = null,
	IDictionary<string, string>? authentication = null,
	int version = 1,
	string? channelMapping = null)
	: CreateSubscriptionRequest(
		method,
		propertyIds,
		new Dictionary<CallbackUrls, string> { { CallbackUrls.Callback, callbackUrl } },
		SubscriptionEnvelope.HyperGuest,
		emails,
		authentication,
		version,
		channelMapping);

/// <summary>
/// Represents a request to create a subscription using the OTA envelope.
/// </summary>
/// <param name="method">The subscription method (ARI vs StaticData)</param>
/// <param name="propertyIds">The set of property IDs.</param>
/// <param name="hotelNotificationUrl">The OTA_HotelAvailNotifRS callback URL.</param>
/// <param name="hotelRateNotificationUrl">The OTA_HotelAvailNotifRS callback URL.</param>
/// <param name="emails">The set of emails used for notification of status changes.</param>
/// <param name="authentication">Any custom authentication values passed to the sub-urls.</param>
/// <param name="version">The version of static-data / ARI</param>
/// <param name="channelMapping">The name of the channel.</param>
public record CreateOTASubscriptionRequest(
	SubscriptionMethod method,
	int[] propertyIds,
	string? hotelNotificationUrl,
	string? hotelRateNotificationUrl,

	string[]? emails = null,
	IDictionary<string, string>? authentication = null,
	int version = 1,
	string? channelMapping = null)
	: CreateSubscriptionRequest(
		method,
		propertyIds,
		MapUrls(hotelNotificationUrl, hotelRateNotificationUrl),
		SubscriptionEnvelope.HyperGuest,
		emails,
		authentication,
		version,
		channelMapping)
{
	static Dictionary<CallbackUrls, string> MapUrls(string? hotelNotificationUrl, string? hotelRateNotificationUrl)
	{
		if (hotelNotificationUrl is null && hotelRateNotificationUrl is null)
		{
			throw new ArgumentException(Resources.Subscription_OTA_MissingUrl);
		}

		var dict = new Dictionary<CallbackUrls, string>();
		if (hotelNotificationUrl is not null)
		{
			dict.Add(CallbackUrls.OTA_HotelAvailNotifRS, hotelNotificationUrl);
		}
		if (hotelRateNotificationUrl is not null)
		{
			dict.Add(CallbackUrls.OTA_HotelRateAmountNotifRS, hotelRateNotificationUrl);
		}

		return dict;
	}
}

/// <summary>
/// Defines the supported callback URLs.
/// </summary>
public enum CallbackUrls
{
	Callback,
	OTA_HotelAvailNotifRS,
	OTA_HotelRateAmountNotifRS
}
#endregion
