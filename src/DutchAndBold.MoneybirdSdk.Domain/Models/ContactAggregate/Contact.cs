using System;
using System.Collections.Generic;
using DutchAndBold.MoneybirdSdk.Domain.Models.CustomerFieldAggregate;
using DutchAndBold.MoneybirdSdk.Domain.Models.EventAggregate;

namespace DutchAndBold.MoneybirdSdk.Domain.Models.ContactAggregate
{
    public class Contact : MoneybirdEntityBase
    {
        public string AdministrationId { get; set; }

        public string CompanyName { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Zipcode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string DeliveryMethod { get; set; }

        public string CustomerId { get; set; }

        public string TaxNumber { get; set; }

        public string ChamberOfCommerce { get; set; }

        public string BankAccount { get; set; }

        public string Attention { get; set; }

        public string Email { get; set; }

        public bool EmailUbl { get; set; }

        public string SendInvoicesToAttention { get; set; }

        public string SendInvoicesToEmail { get; set; }

        public string SendEstimatesToAttention { get; set; }

        public string SendEstimatesToEmail { get; set; }

        public bool SepaActive { get; set; }

        public string SepaIban { get; set; }

        public string SepaIbanAccountName { get; set; }

        public string SepaBic { get; set; }

        public string SepaMandateId { get; set; }

        public object SepaMandateDate { get; set; }

        public string SepaSequenceType { get; set; }

        public string CreditCardNumber { get; set; }

        public string CreditCardReference { get; set; }

        public object CreditCardType { get; set; }

        public object TaxNumberValidatedAt { get; set; }

        public object TaxNumberValid { get; set; }

        public object InvoiceWorkflowId { get; set; }

        public object EstimateWorkflowId { get; set; }

        public string SiIdentifier { get; set; }

        public object SiIdentifierType { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int Version { get; set; }

        public Uri SalesInvoicesUrl { get; set; }

        public List<string> Notes { get; set; }

        public List<CustomFieldValue> CustomFields { get; set; }

        public List<ResourceEvent> Events { get; set; }
    }
}