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
        public MoneybirdRepositoryRead(
            IMoneybirdAdministrationAccessor administrationAccessor,
            string apiPath,
            IMoneybirdClient moneybirdClient)
            : base(administrationAccessor, apiPath, moneybirdClient)
        {
        }

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
        public MoneybirdRepositoryRead(
            IMoneybirdAdministrationAccessor administrationAccessor,
            string apiPath,
            IMoneybirdClient moneybirdClient)
            : base(administrationAccessor, apiPath, moneybirdClient)
        {
        }
    }
}