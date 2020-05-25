using System;
using System.Net.Http;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Contracts;
using DutchAndBold.MoneybirdSdk.Domain.Models.ContactAggregate;
using DutchAndBold.MoneybirdSdk.Repositories;
using Moq;
using Xunit;

namespace DutchAndBold.MoneybirdSdk.Tests.Repositories
{
    public class GenericUpdateRepositoryTests
    {
        [Fact]
        public async Task ItCallsTheRightEndpoint()
        {
            var client = new Mock<IMoneybirdClient>();
            var administrationAccessor = new Mock<IMoneybirdAdministrationAccessor>();

            administrationAccessor.Setup(o => o.Id)
                .Returns("123")
                .Verifiable();

            client.Setup(o => o.PatchAsync<Contact>("v2/123/contacts/1", It.IsAny<HttpContent>(), default))
                .ReturnsAsync(new Contact())
                .Verifiable();

            var repository = new MoneybirdRepositoryUpdate<Contact>(
                "contacts",
                "contact",
                client.Object,
                administrationAccessor.Object);

            await repository.UpdateAsync(
                new Contact()
                {
                    Id = "1"
                });

            client.Verify();
        }

        [Fact]
        public async Task ItWillNotAcceptNewEntity()
        {
            var client = new Mock<IMoneybirdClient>();
            var administrationAccessor = new Mock<IMoneybirdAdministrationAccessor>();

            var repository = new MoneybirdRepositoryUpdate<Contact>(
                "contacts",
                "contact",
                client.Object,
                administrationAccessor.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => repository.UpdateAsync(new Contact()));
        }
    }
}