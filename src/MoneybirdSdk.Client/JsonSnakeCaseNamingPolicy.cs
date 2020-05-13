using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;

namespace MoneybirdSdk.Client
{
    public class JsonSnakeCaseNamingPolicy : JsonNamingPolicy
    {
        [SuppressMessage("ReSharper", "CA1308")]
        public override string ConvertName(string name)
        {
            return string.Concat(name.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x : x.ToString()))
                .ToLowerInvariant();
        }
    }
}