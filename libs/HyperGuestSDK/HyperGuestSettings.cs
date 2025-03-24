// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using FluentValidation;

using Microsoft.Extensions.Options;

namespace HyperGuestSDK;

/// <summary>
/// Represents settings for configuring HyperGuest.
/// </summary>
public class HyperGuestSettings
{
	public const string ConfigurationSection = "HyperGuest";

	/// <summary>
	/// Gets or sets the API key.
	/// </summary>
	public string ApiKey { get; set; } = default!;

	/// <summary>
	/// Gets or sets the API key.
	/// </summary>
	public string BaseUrl { get; set; } = default!;

	/// <summary>
	/// Gets or sets whether to capture request content.
	/// </summary>
	public bool CaptureRequestContent { get; set; }

	/// <summary>
	/// Gets or sets whether to capture response content.
	/// </summary>
	public bool CaptureResponseContent { get; set; }

	/// <summary>
	/// Returns the settings as a wrapped options instance.
	/// </summary>
	/// <returns>The options instance.</returns>
	public IOptions<HyperGuestSettings> AsOptions()
		=> Options.Create(this);

	/// <summary>
	/// Validates the current instance.
	/// </summary>
	public void Validate()
		=> HyperGuestSettingsValidator.Instance.Validate(this);
}

/// <summary>
/// Validates instances of <see cref="HyperGuestSettings"/>.
/// </summary>
public class HyperGuestSettingsValidator : AbstractValidator<HyperGuestSettings>
{
	public static readonly HyperGuestSettingsValidator Instance = new();

	public HyperGuestSettingsValidator()
	{
		bool ValidateUri(string value)
			=> Uri.TryCreate(value, UriKind.Absolute, out var _);

		RuleFor(s => s.BaseUrl)
			.Custom((value, context) =>
			{
				if (!ValidateUri(value))
				{
					context.AddFailure($"'{value}' is not a valid URI.");
				}
			});

		RuleFor(s => s.ApiKey)
			.NotEmpty()
			.WithMessage("The API key must not be empty.");
	}
}
