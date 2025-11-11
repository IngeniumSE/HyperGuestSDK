// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Net.Http.Headers;

using Microsoft.Extensions.Configuration;

using HyperGuestSDK;
using HyperGuestSDK.Api;
using System.Text.Json;
using HyperGuestSDK.Ari;
using HyperGuestSDK.Api.Book;

var settings = GetSettings();
var http = CreateHttpClient();
var api = new HyperGuestApiClient(http, settings);

//var properties = await api.Static.Properties.GetPropertiesAsync();
//Console.WriteLine($"Found {properties.Data.Length} properties.");

//var property = await api.Static.Properties.GetPropertyDetailsAsync(19912);
//var json = JsonSerializer.Serialize(property.Data);
//Console.WriteLine($"Property: {property.Data.Name}");

//var subscriptions = await api.Subscriptions.GetSubscriptionsAsync();
//Console.WriteLine($"Found {subscriptions.Data.Length} subscriptions.");

//var result = await api.Pdm.Subscriptions.CreateSubscriptionAsync(
//	new CreateHyperGuestSubscriptionRequest(
//		SubscriptionMethod.StaticData,
//		[19912],
//		"https://tunnel.ingeniumsoftware.dev/api/hyperguest/subscription/static"
//	));
//Console.WriteLine("Subscription result: ", result.StatusCode);

//var result = await api.Pdm.Subscriptions.GetSubscriptionAsync("10829894293344333110_1_74_0");
//Console.WriteLine("Subscription result: ", JsonSerializer.Serialize(result.Data));

//var update = AriUpdate.FromJsonString(GetARIUpdate());
//Console.WriteLine(update.PropertyId);

//GuestDetails guest = new()
//{
//	BirthDate = new(1984, 3, 11),
//	Contact = new()
//	{
//		Address = "3 Silver Birch Drive",
//		City = "Worthing",
//		Country = "GB",
//		Email = "me@matthewabbott.dev",
//		State = "West Sussex",
//		Phone = "+441234567890",
//		Zip = "BN13 3PP"
//	},
//	Name = new()
//	{
//		First = "Matthew",
//		Last = "Abbott"
//	},
//	Title = "MR"
//};

//var response = await api.Book.CreateAsync(
//	new BookRequest
//	{
//		Dates = new(
//			new(2025, 11, 15),
//			new(2025, 11, 16)
//		),
//		PropertyId = 19912,
//		LeadGuest = guest,
//		Reference = new()
//		{
//			Agency = "REF1234"
//		},
//		Rooms = [

//			new()
//			{
//				RoomId = 31446,
//				RateCode = "FLEX-AI",
//				Guests = [
//					guest
//				],
//				ExpectedPrice = new()
//				{
//					Amount = 77,
//					Currency = "USD"
//				}
//			}
//		],
//		Payment = new()
//		{
//			//Type = PaymentType.External
//			Type = PaymentType.Card,
//			Details = new CardPaymentDetails
//			{
//				Charge = false,
//				Cvv = "100",
//				Expiry = new()
//				{
//					Month = 7,
//					Year = 2026
//				},
//				Name = new()
//				{
//					First = "Matthew",
//					Last = "Abbott"
//				},
//				Number = "4242424242424242"
//			}
//		}
//	});

//Console.WriteLine(response.StatusCode);

//int bookingId = response.Data.Booking?.BookingId ?? 0;

//int bookingId = 1766114;

//var response = await api.Book.GetAsync(bookingId);

string json = """{"content":{"status":"Confirmed","dates":{"from":"2025-11-29","to":"2025-11-30"},"meta":[],"payment":{"type":"external","chargeAmount":{"price":180.2,"currency":"GBP"}},"prices":{"net":{"price":180.2,"currency":"GBP","taxes":[{"description":"VAT of 20% per night (Included in price)","amount":25.03,"currency":"GBP","relation":"included","scope":"per_stay","frequency":"per_night"}]},"sell":{"price":180.2,"currency":"GBP","taxes":[{"description":"VAT of 20% per night (Included in price)","amount":30.03,"currency":"GBP","relation":"included","scope":"per_stay","frequency":"per_night"}]},"commission":{"price":0,"currency":"GBP"},"bar":{"price":180.2,"currency":"GBP"},"fees":[]},"nightlyBreakdown":[{"date":"2025-11-29","prices":{"fees":[],"net":{"price":180.2,"currency":"GBP","taxes":[{"description":"VAT of 20% per night (Included in price)","amount":25.03,"currency":"GBP","relation":"included","scope":"per_stay","frequency":"per_night"}]},"sell":{"price":180.2,"currency":"GBP","taxes":[{"description":"VAT of 20% per night (Included in price)","amount":25.03,"currency":"GBP","relation":"included","scope":"per_stay","frequency":"per_night"}]},"commission":{"price":0,"currency":"GBP"},"bar":{"price":180.2,"currency":"GBP","taxes":[{"description":"VAT of 20% per night (Included in price)","amount":25.03,"currency":"GBP","relation":"included","scope":"per_stay","frequency":"per_night"}]}}}],"rooms":[{"cancellationPolicy":[{"policyId":8476178,"startDate":"2025-11-11 15:23:57","endDate":"2025-11-29 14:00:00","price":{"amount":180.2,"currency":"GBP"}}],"guests":[{"guestId":4609144,"birthDate":"1995-11-11","name":{"first":"Matthew","last":"Abbott"},"contact":{"address":"N/A","city":"N/A","country":"GB","nationality":"GB","email":"me@matthewabbott.dev","phone":"07944747565","state":"N/A","zip":"N/A"},"title":"MRS","age":30}],"specialRequests":[],"remarks":[],"reference":{"property":"2293SF121722"},"itemId":1648485,"roomId":4513037,"ratePlanId":889340,"roomCode":"BZ","roomName":"Standard King","rateCode":"ADSPDESD","ratePlanName":"SpaSeekers - The Essential Spa Break for Two (DBB)","status":"Confirmed","board":"HB","financialModel":{"type":"default","keys":[{"key":"Original amount","value":"180.20 GBP","order":1,"price":{"amount":180.2,"currency":"GBP"},"highlight":false,"calculation":{"type":"base","relation":null,"value":null},"tags":["initial-price"],"description":"Including various taxes"},{"key":"Adjustments","value":"0.00 GBP","order":2,"price":{"amount":0,"currency":"GBP"},"calculation":{"type":"sum","relation":null,"value":{"type":"fixed","value":0,"currency":"GBP"}},"tags":["adjustments-total"],"description":"Total of price adjustments"},{"key":"VAT of 20% per night (Included in price)","order":3,"price":{"amount":30.03,"currency":"GBP"},"value":"30.03 GBP","highlight":false,"calculation":{"type":"sell_tax","relation":"included","value":{"type":"percent","value":20}},"tags":["sell_tax","included"],"description":"VAT of 20% per night (Included in price)"},{"key":"Total Charge","value":"180.20 GBP","order":4,"price":{"amount":180.2,"currency":"GBP"},"calculation":{"type":"sum","relation":null,"value":{"type":"fixed","value":180.2,"currency":"GBP"}},"tags":["total-price"],"description":"Total charge price for the booking"}],"comments":[],"model":"SellGuestToNetAgent"},"propertyId":102242,"prices":{"net":{"price":180.2,"currency":"GBP","taxes":[{"description":"VAT of 20% per night (Included in price)","amount":25.03,"currency":"GBP","relation":"included","scope":"per_stay","frequency":"per_night"}]},"sell":{"price":180.2,"currency":"GBP","taxes":[{"description":"VAT of 20% per night (Included in price)","amount":30.03,"currency":"GBP","relation":"included","scope":"per_stay","frequency":"per_night"}]},"commission":{"price":0,"currency":"GBP"},"bar":{"price":180.2,"currency":"GBP"},"fees":[]},"payment":{"chargeAmount":{"price":180.2,"currency":"GBP"}},"nightlyBreakdown":[{"date":"2025-11-29","prices":{"net":{"price":180.2,"currency":"GBP","taxes":[{"description":"VAT of 20% per night (Included in price)","amount":25.03,"currency":"GBP","relation":"included","scope":"per_stay","frequency":"per_night"}]},"sell":{"price":180.2,"currency":"GBP","taxes":[{"description":"VAT of 20% per night (Included in price)","amount":30.03,"currency":"GBP","relation":"included","scope":"per_stay","frequency":"per_night"}]},"commission":{"price":0,"currency":"GBP"},"bar":{"price":180.2,"currency":"GBP"},"fees":[]}}]}],"bookingId":1783054,"reference":{"agency":"B841470"},"leadGuest":{"guestId":4609145,"birthDate":"1995-11-11","name":{"first":"Matthew","last":"Abbott"},"contact":{"address":"N/A","city":"N/A","country":"GB","nationality":"GB","email":"me@matthewabbott.dev","phone":"07944747565","state":"N/A","zip":"N/A"},"title":"MRS","age":30},"transactions":[],"propertyId":102242,"financialModel":{"type":"default","keys":[{"price":{"amount":180.2,"currency":"GBP"},"key":"Original amount","value":"180.20 GBP","order":1,"highlight":false,"calculation":{"type":"base","relation":null,"value":null},"tags":["initial-price"],"description":"Including various taxes"},{"price":{"amount":0,"currency":"GBP"},"key":"Adjustments","value":"0.00 GBP","order":2,"calculation":{"type":"sum","relation":null,"value":{"type":"fixed","value":0,"currency":"GBP"}},"tags":["adjustments-total"],"description":"Total of price adjustments"},{"price":{"amount":30.03,"currency":"GBP"},"key":"VAT of 20% per night (Included in price)","order":3,"value":"30.03 GBP","highlight":false,"calculation":{"type":"sell_tax","relation":"included","value":{"type":"percent","value":20}},"tags":["sell_tax","included"],"description":"VAT of 20% per night (Included in price)"},{"price":{"amount":180.2,"currency":"GBP"},"key":"Total Charge","value":"180.20 GBP","order":4,"calculation":{"type":"sum","relation":null,"value":{"type":"fixed","value":180.2,"currency":"GBP"}},"tags":["total-price"],"description":"Total charge price for the booking"}],"comments":[],"model":""}},"timestamp":"2025-11-11T15:23:59.706Z"}""";

var response = BookingResponse.FromJsonString(json);
	

Console.WriteLine(json);

//var cancellation = await api.Book.CancelAsync(
//	new CancelBookRequest
//	{
//		BookingId = bookingId,
//		Reason = "Change of plans",
//		Simulation = true
//	});

//Console.WriteLine(response.StatusCode);

//cancellation = await api.Book.CancelAsync(
//	new CancelBookRequest
//	{
//		BookingId = bookingId,
//		Reason = "Change of plans",
//		Simulation = false
//	});

//Console.WriteLine(response.StatusCode);

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

string GetARIUpdate()
{
	return @"{
    ""propertyId"": 19912,
    ""ARIUpdate"": [
        {
            ""date"": ""2025-08-28"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-08-28"",
                ""to"": ""2025-08-28""
            }
        },
        {
            ""date"": ""2025-08-28"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-08-28"",
                ""to"": ""2025-08-28""
            }
        },
        {
            ""date"": ""2025-08-28"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-08-28"",
                ""to"": ""2025-08-28""
            }
        },
        {
            ""date"": ""2025-08-28"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-08-28"",
                ""to"": ""2025-08-28""
            }
        },
        {
            ""date"": ""2025-08-29"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-08-29"",
                ""to"": ""2025-08-29""
            }
        },
        {
            ""date"": ""2025-08-29"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-08-29"",
                ""to"": ""2025-08-29""
            }
        },
        {
            ""date"": ""2025-08-29"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-08-29"",
                ""to"": ""2025-08-29""
            }
        },
        {
            ""date"": ""2025-08-29"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-08-29"",
                ""to"": ""2025-08-29""
            }
        },
        {
            ""date"": ""2025-08-30"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-08-30"",
                ""to"": ""2025-08-30""
            }
        },
        {
            ""date"": ""2025-08-30"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-08-30"",
                ""to"": ""2025-08-30""
            }
        },
        {
            ""date"": ""2025-08-30"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-08-30"",
                ""to"": ""2025-08-30""
            }
        },
        {
            ""date"": ""2025-08-30"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-08-30"",
                ""to"": ""2025-08-30""
            }
        },
        {
            ""date"": ""2025-08-31"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-08-31"",
                ""to"": ""2025-08-31""
            }
        },
        {
            ""date"": ""2025-08-31"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-08-31"",
                ""to"": ""2025-08-31""
            }
        },
        {
            ""date"": ""2025-08-31"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-08-31"",
                ""to"": ""2025-08-31""
            }
        },
        {
            ""date"": ""2025-08-31"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-08-31"",
                ""to"": ""2025-08-31""
            }
        },
        {
            ""date"": ""2025-09-01"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-01"",
                ""to"": ""2025-09-01""
            }
        },
        {
            ""date"": ""2025-09-01"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-01"",
                ""to"": ""2025-09-01""
            }
        },
        {
            ""date"": ""2025-09-01"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-01"",
                ""to"": ""2025-09-01""
            }
        },
        {
            ""date"": ""2025-09-01"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-01"",
                ""to"": ""2025-09-01""
            }
        },
        {
            ""date"": ""2025-09-02"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-02"",
                ""to"": ""2025-09-02""
            }
        },
        {
            ""date"": ""2025-09-02"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-02"",
                ""to"": ""2025-09-02""
            }
        },
        {
            ""date"": ""2025-09-02"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-02"",
                ""to"": ""2025-09-02""
            }
        },
        {
            ""date"": ""2025-09-02"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-02"",
                ""to"": ""2025-09-02""
            }
        },
        {
            ""date"": ""2025-09-03"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-03"",
                ""to"": ""2025-09-03""
            }
        },
        {
            ""date"": ""2025-09-03"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-03"",
                ""to"": ""2025-09-03""
            }
        },
        {
            ""date"": ""2025-09-03"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-03"",
                ""to"": ""2025-09-03""
            }
        },
        {
            ""date"": ""2025-09-03"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-03"",
                ""to"": ""2025-09-03""
            }
        },
        {
            ""date"": ""2025-09-04"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-04"",
                ""to"": ""2025-09-04""
            }
        },
        {
            ""date"": ""2025-09-04"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-04"",
                ""to"": ""2025-09-04""
            }
        },
        {
            ""date"": ""2025-09-04"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-04"",
                ""to"": ""2025-09-04""
            }
        },
        {
            ""date"": ""2025-09-04"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-04"",
                ""to"": ""2025-09-04""
            }
        },
        {
            ""date"": ""2025-09-05"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-05"",
                ""to"": ""2025-09-05""
            }
        },
        {
            ""date"": ""2025-09-05"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-05"",
                ""to"": ""2025-09-05""
            }
        },
        {
            ""date"": ""2025-09-05"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-05"",
                ""to"": ""2025-09-05""
            }
        },
        {
            ""date"": ""2025-09-05"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-05"",
                ""to"": ""2025-09-05""
            }
        },
        {
            ""date"": ""2025-09-06"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-06"",
                ""to"": ""2025-09-06""
            }
        },
        {
            ""date"": ""2025-09-06"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-06"",
                ""to"": ""2025-09-06""
            }
        },
        {
            ""date"": ""2025-09-06"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-06"",
                ""to"": ""2025-09-06""
            }
        },
        {
            ""date"": ""2025-09-06"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-06"",
                ""to"": ""2025-09-06""
            }
        },
        {
            ""date"": ""2025-09-07"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-07"",
                ""to"": ""2025-09-07""
            }
        },
        {
            ""date"": ""2025-09-07"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-07"",
                ""to"": ""2025-09-07""
            }
        },
        {
            ""date"": ""2025-09-07"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-07"",
                ""to"": ""2025-09-07""
            }
        },
        {
            ""date"": ""2025-09-07"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-07"",
                ""to"": ""2025-09-07""
            }
        },
        {
            ""date"": ""2025-09-08"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-08"",
                ""to"": ""2025-09-08""
            }
        },
        {
            ""date"": ""2025-09-08"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-08"",
                ""to"": ""2025-09-08""
            }
        },
        {
            ""date"": ""2025-09-08"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-08"",
                ""to"": ""2025-09-08""
            }
        },
        {
            ""date"": ""2025-09-08"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-08"",
                ""to"": ""2025-09-08""
            }
        },
        {
            ""date"": ""2025-09-09"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-09"",
                ""to"": ""2025-09-09""
            }
        },
        {
            ""date"": ""2025-09-09"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-09"",
                ""to"": ""2025-09-09""
            }
        },
        {
            ""date"": ""2025-09-09"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-09"",
                ""to"": ""2025-09-09""
            }
        },
        {
            ""date"": ""2025-09-09"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-09"",
                ""to"": ""2025-09-09""
            }
        },
        {
            ""date"": ""2025-09-10"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-10"",
                ""to"": ""2025-09-10""
            }
        },
        {
            ""date"": ""2025-09-10"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-10"",
                ""to"": ""2025-09-10""
            }
        },
        {
            ""date"": ""2025-09-10"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-10"",
                ""to"": ""2025-09-10""
            }
        },
        {
            ""date"": ""2025-09-10"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-10"",
                ""to"": ""2025-09-10""
            }
        },
        {
            ""date"": ""2025-09-11"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-11"",
                ""to"": ""2025-09-11""
            }
        },
        {
            ""date"": ""2025-09-11"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-11"",
                ""to"": ""2025-09-11""
            }
        },
        {
            ""date"": ""2025-09-11"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-11"",
                ""to"": ""2025-09-11""
            }
        },
        {
            ""date"": ""2025-09-11"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-11"",
                ""to"": ""2025-09-11""
            }
        },
        {
            ""date"": ""2025-09-12"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-12"",
                ""to"": ""2025-09-12""
            }
        },
        {
            ""date"": ""2025-09-12"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-12"",
                ""to"": ""2025-09-12""
            }
        },
        {
            ""date"": ""2025-09-12"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-12"",
                ""to"": ""2025-09-12""
            }
        },
        {
            ""date"": ""2025-09-12"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-12"",
                ""to"": ""2025-09-12""
            }
        },
        {
            ""date"": ""2025-09-13"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-13"",
                ""to"": ""2025-09-13""
            }
        },
        {
            ""date"": ""2025-09-13"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-13"",
                ""to"": ""2025-09-13""
            }
        },
        {
            ""date"": ""2025-09-13"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-13"",
                ""to"": ""2025-09-13""
            }
        },
        {
            ""date"": ""2025-09-13"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-13"",
                ""to"": ""2025-09-13""
            }
        },
        {
            ""date"": ""2025-09-14"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-14"",
                ""to"": ""2025-09-14""
            }
        },
        {
            ""date"": ""2025-09-14"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-14"",
                ""to"": ""2025-09-14""
            }
        },
        {
            ""date"": ""2025-09-14"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-14"",
                ""to"": ""2025-09-14""
            }
        },
        {
            ""date"": ""2025-09-14"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-14"",
                ""to"": ""2025-09-14""
            }
        },
        {
            ""date"": ""2025-09-15"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-15"",
                ""to"": ""2025-09-15""
            }
        },
        {
            ""date"": ""2025-09-15"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-15"",
                ""to"": ""2025-09-15""
            }
        },
        {
            ""date"": ""2025-09-15"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-15"",
                ""to"": ""2025-09-15""
            }
        },
        {
            ""date"": ""2025-09-15"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-15"",
                ""to"": ""2025-09-15""
            }
        },
        {
            ""date"": ""2025-09-16"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-16"",
                ""to"": ""2025-09-16""
            }
        },
        {
            ""date"": ""2025-09-16"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-16"",
                ""to"": ""2025-09-16""
            }
        },
        {
            ""date"": ""2025-09-16"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-16"",
                ""to"": ""2025-09-16""
            }
        },
        {
            ""date"": ""2025-09-16"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-16"",
                ""to"": ""2025-09-16""
            }
        },
        {
            ""date"": ""2025-09-17"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-17"",
                ""to"": ""2025-09-17""
            }
        },
        {
            ""date"": ""2025-09-17"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-17"",
                ""to"": ""2025-09-17""
            }
        },
        {
            ""date"": ""2025-09-17"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-17"",
                ""to"": ""2025-09-17""
            }
        },
        {
            ""date"": ""2025-09-17"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-17"",
                ""to"": ""2025-09-17""
            }
        },
        {
            ""date"": ""2025-09-18"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-18"",
                ""to"": ""2025-09-18""
            }
        },
        {
            ""date"": ""2025-09-18"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-18"",
                ""to"": ""2025-09-18""
            }
        },
        {
            ""date"": ""2025-09-18"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-18"",
                ""to"": ""2025-09-18""
            }
        },
        {
            ""date"": ""2025-09-18"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-18"",
                ""to"": ""2025-09-18""
            }
        },
        {
            ""date"": ""2025-09-19"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-19"",
                ""to"": ""2025-09-19""
            }
        },
        {
            ""date"": ""2025-09-19"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-19"",
                ""to"": ""2025-09-19""
            }
        },
        {
            ""date"": ""2025-09-19"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-19"",
                ""to"": ""2025-09-19""
            }
        },
        {
            ""date"": ""2025-09-19"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-19"",
                ""to"": ""2025-09-19""
            }
        },
        {
            ""date"": ""2025-09-20"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-20"",
                ""to"": ""2025-09-20""
            }
        },
        {
            ""date"": ""2025-09-20"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-20"",
                ""to"": ""2025-09-20""
            }
        },
        {
            ""date"": ""2025-09-20"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-20"",
                ""to"": ""2025-09-20""
            }
        },
        {
            ""date"": ""2025-09-20"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-20"",
                ""to"": ""2025-09-20""
            }
        },
        {
            ""date"": ""2025-09-21"",
            ""roomTypeCode"": ""SGL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 40
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                }
            ],
            ""roomId"": 31446,
            ""dates"": {
                ""from"": ""2025-09-21"",
                ""to"": ""2025-09-21""
            }
        },
        {
            ""date"": ""2025-09-21"",
            ""roomTypeCode"": ""DBL"",
            ""numberOfAvailableRooms"": 5,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 1,
                                ""infants"": 0
                            },
                            ""price"": 50
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 200.75
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                }
            ],
            ""roomId"": 31447,
            ""dates"": {
                ""from"": ""2025-09-21"",
                ""to"": ""2025-09-21""
            }
        },
        {
            ""date"": ""2025-09-21"",
            ""roomTypeCode"": ""TRPL"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 60
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 80
                        }
                    ]
                }
            ],
            ""roomId"": 122707,
            ""dates"": {
                ""from"": ""2025-09-21"",
                ""to"": ""2025-09-21""
            }
        },
        {
            ""date"": ""2025-09-21"",
            ""roomTypeCode"": ""SUITER"",
            ""numberOfAvailableRooms"": 100,
            ""ratePlans"": [
                {
                    ""ratePlanCode"": ""NON"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 70
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-AI"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 100
                        }
                    ]
                },
                {
                    ""ratePlanCode"": ""FLEX-BB"",
                    ""isOpen"": true,
                    ""isOpenOnArrival"": true,
                    ""isOpenOnDeparture"": true,
                    ""minLOS"": 0,
                    ""maxLOS"": 999,
                    ""prices"": [
                        {
                            ""numberOfGuests"": {
                                ""adults"": 1,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 2,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 3,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        },
                        {
                            ""numberOfGuests"": {
                                ""adults"": 4,
                                ""children"": 0,
                                ""infants"": 0
                            },
                            ""price"": 90
                        }
                    ]
                }
            ],
            ""roomId"": 122708,
            ""dates"": {
                ""from"": ""2025-09-21"",
                ""to"": ""2025-09-21""
            }
        }
    ]
}";
}
