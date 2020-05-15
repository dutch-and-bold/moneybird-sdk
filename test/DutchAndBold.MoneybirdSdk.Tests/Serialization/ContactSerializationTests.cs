using System.IO;
using System.Text.Json;
using DutchAndBold.MoneybirdSdk.Domain.Models.ContactAggregate;
using DutchAndBold.MoneybirdSdk.Extensions;
using Xunit;

namespace DutchAndBold.MoneybirdSdk.Tests.Serialization
{
    public class ContactSerializationTests
    {
        [Fact]
        public void ItCanDeserializeContactApiResponse()
        {
            var responseString = File.ReadAllText("Resources/ApiResponses/contact.json");

            var jsonOptions = new JsonSerializerOptions().Moneybird();

            var contact = JsonSerializer.Deserialize<Contact>(responseString, jsonOptions);

            Assert.Equal("288687886636680348", contact.Id);
        }
    }
}