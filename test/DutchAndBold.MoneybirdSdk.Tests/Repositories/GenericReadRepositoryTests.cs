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
        public async Task ItCallsTheClientCorrectlyWithoutAdministrationId()
        {
            var client = new Mock<IMoneybirdClient>();

            client.Setup(o => o.GetAsync<IEnumerable<Administration>>("v2/administrations?page=1&per_page=50", default))
                .ReturnsAsync(new List<Administration>())
                .Verifiable();
            
            client.Setup(o => o.GetAsync<IEnumerable<Administration>>("v2/administrations?page=2&per_page=50", default))
                .ReturnsAsync(new List<Administration>())
                .Verifiable();

            var repository = new MoneybirdRepositoryRead<Administration>("administrations", client.Object);

            await repository.GetAsync();
            await repository.GetAsync(o => o.Page = 2);

            client.Verify();
        }

        [Fact]
        public async Task ItCallsTheClientCorrectlyWithAdministrationId()
        {
            var client = new Mock<IMoneybirdClient>();
            var administrationAccessor = new Mock<IMoneybirdAdministrationAccessor>();

            administrationAccessor.Setup(o => o.Id)
                .Returns("123")
                .Verifiable();

            client.Setup(o => o.GetAsync<IEnumerable<Administration>>("v2/123/contacts?page=1&per_page=50", default))
                .ReturnsAsync(new List<Administration>())
                .Verifiable();

            var repository = new MoneybirdRepositoryRead<Administration>("contacts", client.Object, administrationAccessor.Object);

            await repository.GetAsync();

            client.Verify();
        }
    }
}