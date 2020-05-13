using System;
using Microsoft.Extensions.DependencyInjection;
using MoneybirdSdk.Client;
using MoneybirdSdk.Client.Contracts;

namespace MoneybirdSdk.Extensions.Microsoft.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMoneybirdSdk(
            this IServiceCollection services,
            Uri moneybirdApiBaseUri)
        {
            services.AddHttpClient<MoneybirdClient>(c => { c.BaseAddress = moneybirdApiBaseUri; })
                .AddHttpMessageHandler<OAuthHeaderHandler>();

            return services;
        }

        public static IServiceCollection AddMoneybirdMachineToMachineAuthentication(
            this IServiceCollection services,
            Uri authority,
            string clientId,
            string clientSecret,
            string authorizationCode)
        {
            services.AddHttpClient("client.authority", c => c.BaseAddress = authority)
                .AddTypedClient<IAccessTokenAcquirer>(
                    (c, s) => new MachineToMachineOAuth2Client(c, clientId, clientSecret, authorizationCode));

            return services;
        }

        public static IServiceCollection AddInMemoryTokenStore(this IServiceCollection services)
        {
            services.AddSingleton<InMemoryAccessTokenStore>();
            services.AddSingleton<IAccessTokenAccessor>(s => s.GetService<InMemoryAccessTokenStore>());
            services.AddSingleton<IAccessTokenStore>(s => s.GetService<InMemoryAccessTokenStore>());

            return services;
        }
    }
}