using DutchAndBold.MoneybirdSdk.Contracts;
using DutchAndBold.MoneybirdSdk.Extensions.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MoneybirdSdk.Extensions.Microsoft.DependencyInjection.Tests
{
    public class AccessTokenStoreIoCTests
    {
        [Fact]
        public void ItResolvesTheSameInMemoryAccessTokenStoreReference()
        {
            var services = new ServiceCollection();

            services.AddInMemoryTokenStore();

            var serviceProvider = services.BuildServiceProvider();

            using var scope1 = serviceProvider.CreateScope();
            using var scope2 = serviceProvider.CreateScope();

            var tokenAccessor1 = scope1.ServiceProvider.GetService<IAccessTokenAccessor>();
            var tokenAccessor2 = scope2.ServiceProvider.GetService<IAccessTokenAccessor>();
            var tokenStore1 = scope1.ServiceProvider.GetService<IAccessTokenStore>();
            var tokenStore2 = scope2.ServiceProvider.GetService<IAccessTokenStore>();
            
            Assert.Same(tokenAccessor1, tokenAccessor2);
            Assert.Same(tokenStore1, tokenStore2);
            Assert.Same(tokenAccessor1, tokenStore1);
        }
    }
}