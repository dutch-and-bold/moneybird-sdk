using System;
using System.Linq;
using DutchAndBold.MoneybirdSdk.Contracts;
using DutchAndBold.MoneybirdSdk.Domain.Models;
using DutchAndBold.MoneybirdSdk.Domain.Query;
using DutchAndBold.MoneybirdSdk.Extensions;

namespace DutchAndBold.MoneybirdSdk.Repositories
{
    public abstract class MoneybirdRepositoryBase
    {
        private readonly string _apiPath;

        private readonly IMoneybirdAdministrationAccessor _administrationAccessor;

        /// <summary>
        /// Moneybird repository base.
        /// </summary>
        /// <param name="apiPath">Api path for the entity (eg: contacts).</param>
        /// <param name="moneybirdClient">Moneybird client</param>
        /// <param name="administrationAccessor">Administration accessor</param>
        protected MoneybirdRepositoryBase(
            string apiPath,
            IMoneybirdClient moneybirdClient,
            IMoneybirdAdministrationAccessor administrationAccessor = default)
        {
            _apiPath = apiPath;
            Client = moneybirdClient ?? throw new ArgumentNullException(nameof(moneybirdClient));
            _administrationAccessor = administrationAccessor;
        }

        protected IMoneybirdClient Client { get; }

        protected string GetApiPath(IMoneybirdQuery query, string apiVersion = "v2")
        {
            return string.Join(
                       '/',
                       new[]
                           {
                               apiVersion, _administrationAccessor?.Id, _apiPath,
                           }
                           .Where(v => v != null)) +
                   query.ToQueryString();
        }

        protected string GetApiPath(IMoneybirdEntity entity = default, string apiVersion = "v2")
        {
            return string.Join(
                '/',
                new[]
                    {
                        apiVersion, _administrationAccessor?.Id, _apiPath, entity?.Id
                    }
                    .Where(v => v != null));
        }
    }
}