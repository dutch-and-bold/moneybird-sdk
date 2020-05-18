using System;
using System.Net.Http;
using DutchAndBold.MoneybirdSdk.Authentication;
using Moq;
using Xunit;

namespace DutchAndBold.MoneybirdSdk.Tests.Authentication
{
    public class OAuth2ClientTests
    {
        [Fact]
        public void ItCanCreateAValidOAuthUriForM2MUse()
        {
            var httpMessageHandler = new Mock<HttpMessageHandler>();
            using var client = new HttpClient(httpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://wubbalubbadubdub.m999/oauth/")
            };

            var oAuthClient = new OAuth2Client(client, "clientId", "clientSecret", new Uri("urn:ietf:wg:oauth:2.0:oob"));

            Assert.Equal(
                new Uri(
                    "https://wubbalubbadubdub.m999/oauth/authorize?client_id=clientId&redirect_uri=urn:ietf:wg:oauth:2.0:oob&response_type=code"),
                oAuthClient.GetAuthenticationUrl());
        }
        
        [Fact]
        public void ItCanCreateAValidOAuthUriForTheEndUser()
        {
            var httpMessageHandler = new Mock<HttpMessageHandler>();
            using var client = new HttpClient(httpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://wubbalubbadubdub.m999/oauth/")
            };

            var oAuthClient = new OAuth2Client(client, "clientId", "clientSecret", new Uri("monogatron:lovefinderrz"));

            Assert.Equal(
                new Uri(
                    "https://wubbalubbadubdub.m999/oauth/authorize?client_id=clientId&redirect_uri=monogatron:lovefinderrz&response_type=code"),
                oAuthClient.GetAuthenticationUrl());
        }
        
        [Fact]
        public void ItCanAddScopesToTheQuery()
        {
            var httpMessageHandler = new Mock<HttpMessageHandler>();
            using var client = new HttpClient(httpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://wubbalubbadubdub.m999/oauth/")
            };

            var oAuthClient = new OAuth2Client(client, "clientId", "clientSecret", new Uri("monogatron:lovefinderrz"));

            Assert.Equal(
                new Uri(
                    "https://wubbalubbadubdub.m999/oauth/authorize?client_id=clientId&redirect_uri=monogatron:lovefinderrz&response_type=code&scope=bank documents sales_invoices"),
                oAuthClient.GetAuthenticationUrl(new []{MoneybirdOAuthScope.Bank, MoneybirdOAuthScope.Documents, MoneybirdOAuthScope.SalesInvoices}));
        }
    }
}