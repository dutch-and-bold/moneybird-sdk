using System;
using System.IO.Abstractions;
using DutchAndBold.MoneybirdSdk.AccessTokenStore.File;
using DutchAndBold.MoneybirdSdk.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace DutchAndBold.MoneybirdSdk.Extensions.Microsoft.DependencyInjection
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
            string clientSecret)
        {
            services.AddHttpClient("client.authority", c => c.BaseAddress = authority)
                .AddTypedClient<IAccessTokenRefresher>(
                    (c, s) => new MachineToMachineOAuth2Client(c, clientId, clientSecret))
                .AddTypedClient<IAccessTokenAcquirer>(
                    (c, s) => new MachineToMachineOAuth2Client(c, clientId, clientSecret));

            return services;
        }

        public static IServiceCollection AddInMemoryTokenStore(this IServiceCollection services)
        {
            services.AddSingleton<InMemoryAccessTokenStore>();
            services.AddSingleton<IAccessTokenAccessor>(s => s.GetService<InMemoryAccessTokenStore>());
            services.AddSingleton<IAccessTokenStore>(s => s.GetService<InMemoryAccessTokenStore>());

            return services;
        }

        public static IServiceCollection AddFileTokenStore(this IServiceCollection services, string fileLocation)
        {
            services.AddSingleton(s => new FileAccessTokenStore(s.GetService<IFile>(), fileLocation));
            services.AddSingleton<IAccessTokenAccessor>(s => s.GetService<FileAccessTokenStore>());
            services.AddSingleton<IAccessTokenStore>(s => s.GetService<FileAccessTokenStore>());

            return services;
        }
    }
}