using System.Collections.Generic;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Contracts;
using DutchAndBold.MoneybirdSdk.Domain.Models.AdministrationAggregate;
using DutchAndBold.MoneybirdSdk.Repositories;
using Moq;
using Xunit;

namespace DutchAndBold.MoneybirdSdk.Tests.Repositories
{
    public class GenericReadRepositoryTests
    {
        [Fact]
        public async Task ItCallsTheClientCorrectly()
        {
            var client = new Mock<IMoneybirdClient>();

            client.Setup(o => o.GetAsync<IEnumerable<Administration>>("v2/administrations?page=1&per_page=50", default))
                .ReturnsAsync(new List<Administration>())
                .Verifiable();

            var repository = new MoneybirdRepositoryRead<Administration>("v2/administrations", client.Object);

            await repository.GetAsync();

            client.Verify();
        }
    }
}