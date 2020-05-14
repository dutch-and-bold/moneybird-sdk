using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using DutchAndBold.MoneybirdSdk.Domain.Models.AdministrationAggregate;
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

            var jsonOptions = new JsonSerializerOptions().Moneybird();

            var administrations = JsonSerializer.Deserialize<List<Administration>>(responseString, jsonOptions);

            Assert.Equal("322222222211111111", administrations.First().Id);
            
            Assert.Equal(TZConvert.GetTimeZoneInfo("Europe/Amsterdam"), administrations.First().TimeZone);
            Assert.Equal("EUR", administrations.First().Currency.IsoSymbol);

            var jsonString = JsonSerializer.Serialize(administrations, jsonOptions);

            Assert.Contains("time_zone\":\"Europe/Amsterdam", jsonString, StringComparison.InvariantCulture);
            Assert.Contains("currency\":\"EUR", jsonString, StringComparison.InvariantCulture);
        }
    }
}