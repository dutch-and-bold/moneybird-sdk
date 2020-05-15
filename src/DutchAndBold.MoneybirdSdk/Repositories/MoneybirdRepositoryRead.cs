using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Contracts;
using DutchAndBold.MoneybirdSdk.Domain.Models;
using DutchAndBold.MoneybirdSdk.Domain.Query;
using DutchAndBold.MoneybirdSdk.Domain.Repositories;
using DutchAndBold.MoneybirdSdk.Extensions;

namespace DutchAndBold.MoneybirdSdk.Repositories
{
    public class MoneybirdRepositoryRead<TMoneybirdEntity, TMoneybirdQuery>
        : IMoneybirdRepositoryRead<TMoneybirdEntity, TMoneybirdQuery>
        where TMoneybirdEntity : IMoneybirdEntity
        where TMoneybirdQuery : IMoneybirdQuery
    {
        private readonly string _apiPath;

        private readonly IMoneybirdClient _moneybirdClient;

        public MoneybirdRepositoryRead(string apiPath, IMoneybirdClient moneybirdClient)
        {
            _apiPath = apiPath;
            _moneybirdClient = moneybirdClient;
        }

        public Task<IEnumerable<TMoneybirdEntity>> GetAsync(
            Action<TMoneybirdQuery> action,
            CancellationToken cancellationToken = default)
        {
            var query = Activator.CreateInstance<TMoneybirdQuery>();
            action?.Invoke(query);

            return _moneybirdClient.GetAsync<IEnumerable<TMoneybirdEntity>>(
                $"{_apiPath}{query.ToQueryString()}",
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
        public MoneybirdRepositoryRead(string apiPath, IMoneybirdClient moneybirdClient)
            : base(apiPath, moneybirdClient)
        {
        }
    }
}