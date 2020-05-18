using System;
using System.IO.Abstractions;
using DutchAndBold.MoneybirdSdk.AccessTokenStore.File;
using DutchAndBold.MoneybirdSdk.Authentication;
using DutchAndBold.MoneybirdSdk.Contracts;
using DutchAndBold.MoneybirdSdk.Domain.Models;
using DutchAndBold.MoneybirdSdk.Domain.Models.AdministrationAggregate;
using DutchAndBold.MoneybirdSdk.Domain.Models.ContactAggregate;
using DutchAndBold.MoneybirdSdk.Domain.Repositories;
using DutchAndBold.MoneybirdSdk.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DutchAndBold.MoneybirdSdk.Extensions.Microsoft.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMoneybirdSdk(
            this IServiceCollection services,
            Uri moneybirdApiBaseUri,
            string? administrationId = null)
        {
            services.AddTransient<OAuthHeaderHandler>();

            services.AddHttpClient("moneybird", c => { c.BaseAddress = moneybirdApiBaseUri; })
                .AddHttpMessageHandler<OAuthHeaderHandler>()
                .AddTypedClient<IMoneybirdClient, MoneybirdClient>();

            services.AddScoped<IMoneybirdRepositoryRead<Administration>>(
                s => new MoneybirdRepositoryRead<Administration>(
                    MoneybirdApiEndpoints.Administrations,
                    s.GetService<IMoneybirdClient>()));

            services.AddMoneybirdRepositories(administrationId);

            return services;
        }

        public static IServiceCollection AddMoneybirdMachineToMachineAuthentication(
            this IServiceCollection services,
            Uri authority,
            string clientId,
            string clientSecret)
        {
            return services.AddMoneybirdAuthentication(
                authority,
                clientId,
                clientSecret,
                new Uri("urn:ietf:wg:oauth:2.0:oob"));
        }

        public static IServiceCollection AddMoneybirdAuthentication(
            this IServiceCollection services,
            Uri authority,
            string clientId,
            string clientSecret,
            Uri redirectUri)
        {
            services.AddHttpClient("moneybird.authority", c => c.BaseAddress = authority)
                .AddTypedClient<IAccessTokenRefresher>(
                    (c, s) => new OAuth2Client(c, clientId, clientSecret, redirectUri))
                .AddTypedClient<IAccessTokenAcquirer>(
                    (c, s) => new OAuth2Client(c, clientId, clientSecret, redirectUri));

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

        private static IServiceCollection AddMoneybirdRepositories(
            this IServiceCollection services,
            string? administrationId = null)
        {
            services.AddScoped<IMoneybirdAdministrationAccessor>(
                s => new AdministrationAccessor()
                {
                    Id = administrationId
                });

            services.AddReadWriteUpdateDeleteRepository<Contact>("contacts", "contact");
            return services;
        }

        /// <summary>
        /// Adds repositories for read, write, update and delete.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="apiPath">Api endpoint path (eg: contacts).</param>
        /// <param name="objectKey">Api post body document key (eg: contact).</param>
        /// <typeparam name="TMoneybirdEntity"></typeparam>
        /// <returns></returns>
        private static IServiceCollection AddReadWriteUpdateDeleteRepository<TMoneybirdEntity>(
            this IServiceCollection services,
            string apiPath,
            string objectKey)
            where TMoneybirdEntity : class, IMoneybirdEntity
        {
            services.AddScoped<IMoneybirdRepositoryRead<TMoneybirdEntity>>(
                s => new MoneybirdRepositoryRead<TMoneybirdEntity>(
                    apiPath,
                    s.GetService<IMoneybirdClient>(),
                    s.GetService<IMoneybirdAdministrationAccessor>()));

            services.AddScoped<IMoneybirdRepositoryStore<TMoneybirdEntity>>(
                s => new MoneybirdRepositoryStore<TMoneybirdEntity>(
                    apiPath,
                    objectKey,
                    s.GetService<IMoneybirdClient>(),
                    s.GetService<IMoneybirdAdministrationAccessor>()));

            return services;
        }
    }
}