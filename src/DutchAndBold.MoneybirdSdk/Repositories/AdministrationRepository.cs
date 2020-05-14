using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Contracts;
using DutchAndBold.MoneybirdSdk.Domain.Models.AdministrationAggregate;
using DutchAndBold.MoneybirdSdk.Domain.Repositories;

namespace DutchAndBold.MoneybirdSdk.Repositories
{
    public class AdministrationRepository : IMoneybirdRepositoryRead<Administration>
    {
        private readonly IMoneybirdClient _moneybirdClient;

        public AdministrationRepository(IMoneybirdClient moneybirdClient)
        {
            _moneybirdClient = moneybirdClient;
        }

        public Task<IEnumerable<Administration>> GetAsync(CancellationToken cancellationToken = default)
        {
            return _moneybirdClient.GetAsync<IEnumerable<Administration>>("v2/administrations", cancellationToken);
        }
    }
}