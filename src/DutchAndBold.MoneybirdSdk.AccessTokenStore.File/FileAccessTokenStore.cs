using System;
using System.IO.Abstractions;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Contracts;
using DutchAndBold.MoneybirdSdk.Models;

namespace DutchAndBold.MoneybirdSdk.AccessTokenStore.File
{
    public class FileAccessTokenStore : IAccessTokenStore, IAccessTokenAccessor
    {
        private readonly IFile _systemFile;

        private readonly string _fileLocation;

        public FileAccessTokenStore(IFile systemFile, string fileLocation)
        {
            _systemFile = systemFile ?? throw new ArgumentNullException(nameof(systemFile));
            _fileLocation = fileLocation;
            AccessToken = ReadFromFileLocationAsync().Result;
        }

        public async Task StoreTokenAsync(AccessToken accessToken, CancellationToken cancellationToken = default)
        {
            if (AccessToken == accessToken)
            {
                return;
            }

            AccessToken = accessToken;
            await WriteToFileLocationAsync(accessToken, cancellationToken);
        }

        public AccessToken AccessToken { get; private set; }

        private async Task<AccessToken> ReadFromFileLocationAsync(CancellationToken cancellationToken = default)
        {
            if (!_systemFile.Exists(_fileLocation))
            {
                return null;
            }

            return JsonSerializer.Deserialize<AccessToken>(
                await _systemFile.ReadAllTextAsync(_fileLocation, cancellationToken));
        }

        private Task WriteToFileLocationAsync(AccessToken accessToken, CancellationToken cancellationToken = default)
        {
            return _systemFile.WriteAllTextAsync(
                _fileLocation,
                JsonSerializer.Serialize(
                    accessToken,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true,
                    }),
                cancellationToken);
        }
    }
}