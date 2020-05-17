using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DutchAndBold.MoneybirdSdk.Contracts
{
    public interface IMoneybirdClient
    {
        /// <summary>
        /// Makes a GET request to the Moneybird api.
        /// </summary>
        /// <param name="path">Path to be appended to the base endpoint url.</param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T">Type to deserialize to.</typeparam>
        /// <returns>Deserialized <see cref="T"/>.</returns>
        public Task<T> GetAsync<T>(string path, CancellationToken cancellationToken = default);

        /// <summary>
        /// Makes an POST request to the Moneybird API.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Task<T> PostAsync<T>(string path, HttpContent body, CancellationToken cancellationToken = default);
    }
}