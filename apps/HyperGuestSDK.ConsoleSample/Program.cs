﻿// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Net.Http.Headers;

using Microsoft.Extensions.Configuration;

using HyperGuestSDK;
using HyperGuestSDK.Api;
using System.Text.Json;

var settings = GetSettings();
var http = CreateHttpClient();
var api = new HyperGuestApiClient(http, settings);

//var properties = await api.Properties.GetPropertiesAsync();
//Console.WriteLine($"Found {properties.Data.Length} properties.");

var property = await api.Properties.GetPropertyDetailsAsync(19912);

var json = JsonSerializer.Serialize(property.Data);
Console.WriteLine($"Property: {property.Data.Name}");	

HyperGuestSettings GetSettings()
{
	var configuration = new ConfigurationBuilder()
		.AddJsonFile("./appsettings.json", optional: false)
		.AddJsonFile("./appsettings.env.json", optional: true)
		.Build();

	HyperGuestSettings settings = new();
	configuration.GetSection(HyperGuestSettings.ConfigurationSection).Bind(settings);

	settings.Validate();

	return settings;
}

HttpClient CreateHttpClient()
{
	var http = new HttpClient();

	http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

	return http;
}
