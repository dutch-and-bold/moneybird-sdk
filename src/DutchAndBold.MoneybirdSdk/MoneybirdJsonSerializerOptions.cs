using System;
using System.Text.Json;
using DutchAndBold.MoneybirdSdk.Serialization;

namespace DutchAndBold.MoneybirdSdk
{
    public static class MoneybirdJsonSerializerOptions
    {
        public static JsonSerializerOptions Moneybird(this JsonSerializerOptions jsonSerializerOptions)
        {
            if (jsonSerializerOptions == null)
            {
                throw new ArgumentNullException(nameof(jsonSerializerOptions));
            }

            jsonSerializerOptions.Converters.Add(new JsonTimeZoneConverter());
            jsonSerializerOptions.Converters.Add(new JsonCurrencyConverter());
            jsonSerializerOptions.PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy();

            return jsonSerializerOptions;
        }
    }
}