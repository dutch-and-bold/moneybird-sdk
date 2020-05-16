using DutchAndBold.MoneybirdSdk.Domain.Query;
using DutchAndBold.MoneybirdSdk.Extensions;
using Xunit;

namespace DutchAndBold.MoneybirdSdk.Tests.Serialization
{
    public class MoneybirdQueryTests
    {
        [Fact]
        public void ItCanBeConvertedToAString()
        {
            var query = new MoneybirdQuery()
            {
                Page = 2,
                PerPage = 45,
            };

            var queryString = query.ToQueryString();
            
            Assert.Equal("?page=2&per_page=45", queryString);
        }
        
        [Fact]
        public void ItCreateAnCorrectQueryStringForContacts()
        {
            var query = new ContactQuery()
            {
                Page = 2,
                PerPage = 45,
                Query = "test"
            };

            var queryString = query.ToQueryString();
            
            Assert.Equal("?query=test&page=2&per_page=45", queryString);
        }
    }
}