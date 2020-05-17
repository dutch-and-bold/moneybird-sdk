using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Contracts;
using DutchAndBold.MoneybirdSdk.Domain.Models;
using DutchAndBold.MoneybirdSdk.Domain.Query;
using DutchAndBold.MoneybirdSdk.Domain.Repositories;

namespace DutchAndBold.MoneybirdSdk.Repositories
{
    public class MoneybirdRepositoryRead<TMoneybirdEntity, TMoneybirdQuery>
        : MoneybirdRepositoryBase, IMoneybirdRepositoryRead<TMoneybirdEntity, TMoneybirdQuery>
        where TMoneybirdEntity : IMoneybirdEntity
        where TMoneybirdQuery : IMoneybirdQuery
    {
        /// <inheritdoc cref="MoneybirdRepositoryBase"/>
        public MoneybirdRepositoryRead(
            string apiPath,
            IMoneybirdClient moneybirdClient,
            IMoneybirdAdministrationAccessor administrationAccessor = default)
            : base(apiPath, moneybirdClient, administrationAccessor)
        {
        }

        /// <summary>
        /// Retrieves entities from the API using an HTTP connection.
        /// </summary>
        /// <param name="action">Is given an empty <see cref="TMoneybirdQuery"/>.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<TMoneybirdEntity>> GetAsync(
            Action<TMoneybirdQuery> action,
            CancellationToken cancellationToken = default)
        {
            var query = Activator.CreateInstance<TMoneybirdQuery>();
            action?.Invoke(query);

            return Client.GetAsync<IEnumerable<TMoneybirdEntity>>(
                GetApiPath(query),
                cancellationToken);
        }

        /// <summary>
        /// Retrieves entities from the API using an HTTP connection.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<TMoneybirdEntity>> GetAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync(default, cancellationToken);
        }
    }

    public class MoneybirdRepositoryRead<TMoneybirdEntity>
        : MoneybirdRepositoryRead<TMoneybirdEntity, MoneybirdQuery>,
            IMoneybirdRepositoryRead<TMoneybirdEntity>
        where TMoneybirdEntity : IMoneybirdEntity
    {
        /// <inheritdoc cref="MoneybirdRepositoryBase"/>
        public MoneybirdRepositoryRead(
            string apiPath,
            IMoneybirdClient moneybirdClient,
            IMoneybirdAdministrationAccessor administrationAccessor = default)
            : base(apiPath, moneybirdClient, administrationAccessor)
        {
        }
    }
}