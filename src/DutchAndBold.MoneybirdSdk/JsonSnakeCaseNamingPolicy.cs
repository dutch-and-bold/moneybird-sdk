using System.Text.Json;
using DutchAndBold.MoneybirdSdk.Extensions;

namespace DutchAndBold.MoneybirdSdk
{
    public class JsonSnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return name.PascalToSnakeCase();
        }
    }
}