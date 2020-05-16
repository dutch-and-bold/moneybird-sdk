namespace DutchAndBold.MoneybirdSdk.Domain.Query
{
    public class ContactQuery : MoneybirdQuery
    {
        public string Query { get; set; }

        public string CompanyName { get; set; }

        public string Attention { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Zipcode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string CustomerId { get; set; }

        public string TaxNumber { get; set; }

        public string ChamberOfCommerce { get; set; }

        public string BankAccount { get; set; }
    }
}