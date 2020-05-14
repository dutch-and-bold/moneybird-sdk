using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using NMoneys;

namespace DutchAndBold.MoneybirdSdk.Serialization
{
    public class JsonCurrencyConverter : JsonConverter<Currency>
    {
        public override Currency Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            Currency.Get(reader.GetString());

        public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options) =>
            writer?.WriteStringValue(value?.IsoSymbol ?? "null");
    }
}