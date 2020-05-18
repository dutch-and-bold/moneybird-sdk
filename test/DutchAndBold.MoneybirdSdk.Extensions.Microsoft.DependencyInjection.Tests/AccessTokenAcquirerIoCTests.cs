using System;
using System.Net.Http;
using System.Reflection;
using DutchAndBold.MoneybirdSdk.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DutchAndBold.MoneybirdSdk.Extensions.Microsoft.DependencyInjection.Tests
{
    public class AccessTokenAcquirerIoCTests
    {
        private const string AuthorityUrl = "https://wubbalubbadubdub.m9999";

        [Fact]
        public void ItCanResolveTheCorrectHttpClient()
        {
            var services = new ServiceCollection();

            services.AddMoneybirdMachineToMachineAuthentication(
                new Uri(AuthorityUrl),
                "clientId",
                "clientSecret");

            var serviceProvider = services.BuildServiceProvider();

            var accessTokenAcquirer = serviceProvider.GetService<IAccessTokenAcquirer>();

            Assert.IsType<MachineToMachineOAuth2Client>(accessTokenAcquirer);

            var clientField =
                typeof(MachineToMachineOAuth2Client).GetField("_httpClient", BindingFlags.NonPublic | BindingFlags.Instance);

            var client = (HttpClient)clientField.GetValue(accessTokenAcquirer);

            Assert.Equal(new Uri(AuthorityUrl), client.BaseAddress);
        }
    }
}