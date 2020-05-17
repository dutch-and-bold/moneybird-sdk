using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Contracts;
using DutchAndBold.MoneybirdSdk.Domain.Models;
using DutchAndBold.MoneybirdSdk.Domain.Repositories;
using DutchAndBold.MoneybirdSdk.Extensions;

namespace DutchAndBold.MoneybirdSdk.Repositories
{
    public class MoneybirdRepositoryStore<TMoneybirdEntity>
        : MoneybirdRepositoryBase, IMoneybirdRepositoryStore<TMoneybirdEntity>
        where TMoneybirdEntity : class, IMoneybirdEntity
    {
        private readonly string _objectKey;

        /// <summary>
        /// Moneybird Repository for storing new entities (POST).
        /// </summary>
        /// <param name="apiPath">Api path for the entity (eg: contacts).</param>
        /// <param name="objectKey">Object key for the POST body (eg: contact).</param>
        /// <param name="moneybirdClient">Moneybird client</param>
        /// <param name="administrationAccessor">Administration accessor</param>
        /// <exception cref="ArgumentNullException">Thrown when administrationAccessor is null.</exception>
        public MoneybirdRepositoryStore(
            string apiPath,
            string objectKey,
            IMoneybirdClient moneybirdClient,
            IMoneybirdAdministrationAccessor administrationAccessor)
            : base(apiPath, moneybirdClient, administrationAccessor)
        {
            if (administrationAccessor == null)
            {
                throw new ArgumentNullException(nameof(administrationAccessor));
            }

            _objectKey = objectKey;
        }

        /// <summary>
        /// Stores new entity to the API using an HTTP connection.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A new <see cref="TMoneybirdEntity"/>.</returns>
        public async Task<TMoneybirdEntity> StoreAsync(
            TMoneybirdEntity entity,
            CancellationToken cancellationToken = default)
        {
            var dictionary = new Dictionary<string, TMoneybirdEntity>
            {
                {
                    _objectKey, entity
                }
            };

            using var body = new JsonContent<Dictionary<string, TMoneybirdEntity>>(
                dictionary,
                new JsonSerializerOptions().Moneybird());

            return await Client.PostAsync<TMoneybirdEntity>(
                GetApiPath(entity),
                body,
                cancellationToken);
        }
    }
}