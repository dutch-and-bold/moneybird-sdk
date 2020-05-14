using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using DutchAndBold.MoneybirdSdk.Domain.Models.AdministrationAggregate;
using DutchAndBold.MoneybirdSdk.Serialization;
using NodaMoney;
using TimeZoneConverter;
using Xunit;

namespace DutchAndBold.MoneybirdSdk.Tests.Serialization
{
    public class AdministrationSerializationTests
    {
        [Fact]
        public void ItCanDeserializeAdministrationApiResponseWithIanaTimeZone()
        {
            var responseString = File.ReadAllText("Resources/ApiResponses/administration.json");

            var jsonOptions = new JsonSerializerOptions()
            {
                Converters =
                {
                    new JsonTimeZoneConverter(),
                    new JsonCurrencyConverter()
                },
                PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy(),
            };

            var administrations = JsonSerializer.Deserialize<List<Administration>>(responseString, jsonOptions);

            Assert.Equal(TZConvert.GetTimeZoneInfo("Europe/Amsterdam"), administrations.First().TimeZone);
            Assert.Equal(Currency.FromCode("EUR"), administrations.First().Currency);

            var jsonString = JsonSerializer.Serialize(administrations, jsonOptions);

            Assert.Contains("time_zone\":\"Europe/Amsterdam", jsonString, StringComparison.InvariantCulture);
            Assert.Contains("currency\":\"EUR", jsonString, StringComparison.InvariantCulture);
        }
    }
}