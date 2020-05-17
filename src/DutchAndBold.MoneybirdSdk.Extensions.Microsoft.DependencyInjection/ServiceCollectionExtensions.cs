using System;
using System.IO.Abstractions;
using DutchAndBold.MoneybirdSdk.AccessTokenStore.File;
using DutchAndBold.MoneybirdSdk.Contracts;
using DutchAndBold.MoneybirdSdk.Domain.Models.AdministrationAggregate;
using DutchAndBold.MoneybirdSdk.Domain.Repositories;
using DutchAndBold.MoneybirdSdk.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DutchAndBold.MoneybirdSdk.Extensions.Microsoft.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMoneybirdSdk(
            this IServiceCollection services,
            Uri moneybirdApiBaseUri)
        {
            services.AddTransient<OAuthHeaderHandler>();

            services.AddHttpClient("moneybird", c => { c.BaseAddress = moneybirdApiBaseUri; })
                .AddHttpMessageHandler<OAuthHeaderHandler>()
                .AddTypedClient<IMoneybirdClient, MoneybirdClient>();

            services.AddScoped<IMoneybirdRepositoryRead<Administration>>(
                s => new MoneybirdRepositoryRead<Administration>(
                    MoneybirdApiEndpoints.Administrations,
                    s.GetService<IMoneybirdClient>()));

            return services;
        }

        public static IServiceCollection AddMoneybirdMachineToMachineAuthentication(
            this IServiceCollection services,
            Uri authority,
            string clientId,
            string clientSecret)
        {
            services.AddHttpClient("moneybird.authority", c => c.BaseAddress = authority)
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
            services.AddTransient<IFileSystem, FileSystem>();
            services.AddTransient(s => s.GetService<IFileSystem>().File);
            services.AddSingleton(s => new FileAccessTokenStore(s.GetService<IFile>(), fileLocation));
            services.AddSingleton<IAccessTokenAccessor>(s => s.GetService<FileAccessTokenStore>());
            services.AddSingleton<IAccessTokenStore>(s => s.GetService<FileAccessTokenStore>());

            return services;
        }
    }
}