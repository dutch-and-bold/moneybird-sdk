using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DutchAndBold.MoneybirdSdk.Serialization;

namespace DutchAndBold.MoneybirdSdk.Extensions
{
    public static class MoneybirdJsonSerializerOptions
    {
        /// <summary>
        /// Applies configuration for Moneybird (de)serialization.
        /// </summary>
        /// <param name="jsonSerializerOptions"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static JsonSerializerOptions Moneybird(this JsonSerializerOptions jsonSerializerOptions)
        {
            if (jsonSerializerOptions == null)
            {
                throw new ArgumentNullException(nameof(jsonSerializerOptions));
            }

            jsonSerializerOptions.PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy();

            jsonSerializerOptions.Converters.Add(new JsonStringEnumMemberConverter(JsonNamingPolicy.CamelCase, false));
            jsonSerializerOptions.Converters.Add(new JsonTimeZoneConverter());
            jsonSerializerOptions.Converters.Add(new JsonCurrencyConverter());

            return jsonSerializerOptions;
        }
    }
}