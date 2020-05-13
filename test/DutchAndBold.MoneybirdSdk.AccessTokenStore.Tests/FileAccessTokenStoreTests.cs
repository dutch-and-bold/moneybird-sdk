using System.IO.Abstractions;
using System.Threading;
using DutchAndBold.MoneybirdSdk.AccessTokenStore.File;
using Moq;
using Xunit;

namespace MoneybirdSdk.Client.AccessTokenStore.Tests
{
    public class FileAccessTokenStoreTests
    {
        private const string FileLocation = "/mnt/secrets/concentrated-dark-matter/secret.json";

        [Fact]
        public void ItCanConstructFromFileContents()
        {
            var fileMock = new Mock<IFile>();

            fileMock.Setup(o => o.Exists(FileLocation)).Returns(true);
            
            fileMock.Setup(o => o.ReadAllTextAsync(FileLocation, It.IsAny<CancellationToken>()))
                .Returns(System.IO.File.ReadAllTextAsync("Resources/token.json"));

            var accessTokenStore = new FileAccessTokenStore( 
                fileMock.Object,
                FileLocation);

            Assert.Equal("access_token", accessTokenStore.AccessToken.Value);
        }
    }
}