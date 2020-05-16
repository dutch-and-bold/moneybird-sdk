using DutchAndBold.MoneybirdSdk.Contracts;
using DutchAndBold.MoneybirdSdk.Domain.Query;
using DutchAndBold.MoneybirdSdk.Extensions;

namespace DutchAndBold.MoneybirdSdk.Repositories
{
    public abstract class MoneybirdRepositoryBase
    {
        private readonly IMoneybirdAdministrationAccessor _administrationAccessor;

        private readonly string _apiPath;

        protected MoneybirdRepositoryBase(
            IMoneybirdAdministrationAccessor administrationAccessor,
            string apiPath,
            IMoneybirdClient moneybirdClient)
        {
            _administrationAccessor = administrationAccessor;
            _apiPath = apiPath;
            Client = moneybirdClient;
        }

        protected IMoneybirdClient Client { get; }

        protected string GetApiPath(IMoneybirdQuery query, string apiVersion = "v2")
        {
            var administrationPart = _administrationAccessor?.Id != null ? _administrationAccessor.Id + "/" : "";
            return $"{apiVersion}/{administrationPart}{_apiPath}{query.ToQueryString()}";
        }
    }
}