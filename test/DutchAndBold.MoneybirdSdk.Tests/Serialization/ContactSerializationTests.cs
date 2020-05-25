using System.Globalization;
using System.IO;
using System.Text.Json;
using DutchAndBold.MoneybirdSdk.Domain.Models.ContactAggregate;
using DutchAndBold.MoneybirdSdk.Domain.Models.EventAggregate;
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
            Assert.Equal("288417792282068499", contact.AdministrationId);
            Assert.Equal("Company name", contact.CompanyName);
            Assert.Equal("First-Name", contact.Firstname);
            Assert.Equal("Last-Name", contact.Lastname);
            Assert.Equal("Address 123", contact.Address1);
            Assert.Equal("", contact.Address2);
            Assert.Equal("1234AB", contact.Zipcode);
            Assert.Equal("City Name", contact.City);
            Assert.Equal("NL", contact.Country);
            Assert.Equal("0123456789", contact.Phone);
            Assert.Equal("Email", contact.DeliveryMethod);
            Assert.Equal("1", contact.CustomerId);
            Assert.Equal("NL1234567890B01", contact.TaxNumber);
            Assert.Equal("12345678", contact.ChamberOfCommerce);
            Assert.Equal("NL02ABNA2532528516", contact.BankAccount);
            Assert.Equal("First-Name Last-Name", contact.Attention);
            Assert.Equal("wubbalubbadubdub@dutchandbold.com", contact.Email);
            Assert.True(contact.EmailUbl);
            Assert.Equal("First-Name Last-Name", contact.SendInvoicesToAttention);
            Assert.Equal("wubbalubbadubdub@dutchandbold.com", contact.SendInvoicesToEmail);
            Assert.Equal("First-Name Last-Name", contact.SendEstimatesToAttention);
            Assert.Equal("wubbalubbadubdub@dutchandbold.com", contact.SendEstimatesToEmail);
            Assert.False(contact.SepaActive);
            Assert.Equal("NL02ABNA2532528516", contact.SepaIban);
            Assert.Equal("FAKE DUMMY IBAN", contact.SepaIbanAccountName);
            Assert.Equal("ABNANL2A", contact.SepaBic);
            Assert.Equal("", contact.SepaMandateId);
            Assert.Null(contact.SepaMandateDate);
            Assert.Equal("RCUR", contact.SepaSequenceType);
            Assert.Equal("", contact.CreditCardNumber);
            Assert.Equal("", contact.CreditCardReference);
            Assert.Null(contact.CreditCardType);
            Assert.Equal(
                "05/15/2020 09:17:26",
                contact.TaxNumberValidatedAt.ToUniversalTime().ToString(CultureInfo.InvariantCulture));
            Assert.False(contact.TaxNumberValid);
            Assert.Equal("288417793178600882", contact.InvoiceWorkflowId);
            Assert.Equal("288417793218446777", contact.EstimateWorkflowId);
            Assert.Equal("12345678", contact.SiIdentifier);
            Assert.Equal("NL:KVK", contact.SiIdentifierType);
            Assert.Equal(
                "05/15/2020 09:17:24",
                contact.CreatedAt.ToUniversalTime().ToString(CultureInfo.InvariantCulture));
            Assert.Equal(
                "05/15/2020 09:17:26",
                contact.UpdatedAt.ToUniversalTime().ToString(CultureInfo.InvariantCulture));
            Assert.Equal(1589534246, contact.Version);
            Assert.Equal(
                "https://moneybird.com/288417792282068499/sales_invoices/ee6dde60dac83b65e0fc8c95e4502048ddc6d71a9539c0f50c8a442297b66c12/all",
                contact.SalesInvoicesUrl.ToString());

            Assert.Empty(contact.Notes);
            Assert.Single(contact.CustomFields);
            Assert.Equal("288687848325908322", contact.CustomFields[0].Id);
            Assert.Equal("Test field", contact.CustomFields[0].Name);
            Assert.Equal("Test", contact.CustomFields[0].Value);
            Assert.Single(contact.Events);
            Assert.Equal("288417792282068499", contact.Events[0].AdministrationId);
            Assert.Equal("212349556969440325", contact.Events[0].UserId);
            Assert.Equal(ResourceEventAction.ContactCreated, contact.Events[0].Action);
            Assert.Null(contact.Events[0].LinkEntityId);
            Assert.Null(contact.Events[0].LinkEntityType);
            Assert.Equal(
                "05/15/2020 09:17:24",
                contact.Events[0].CreatedAt.ToUniversalTime().ToString(CultureInfo.InvariantCulture));
            Assert.Equal(
                "05/15/2020 09:17:24",
                contact.Events[0].UpdatedAt.ToUniversalTime().ToString(CultureInfo.InvariantCulture));
        }

        [Fact]
        public void ItCanSerializeBack()
        {
            var responseString = File.ReadAllText("Resources/ApiResponses/contact.json");
            var serializationAssertion = File.ReadAllText("Resources/Serialized/contact.json");

            var jsonOptions = new JsonSerializerOptions().Moneybird();
            jsonOptions.WriteIndented = true;

            var contact = JsonSerializer.Deserialize<Contact>(responseString, jsonOptions);
            var serialized = JsonSerializer.Serialize(contact, jsonOptions);

            Assert.Equal(serializationAssertion, serialized);
        }
    }
}