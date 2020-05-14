using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using TimeZoneConverter;

namespace DutchAndBold.MoneybirdSdk.Serialization
{
    public class JsonTimeZoneConverter : JsonConverter<TimeZoneInfo>
    {
        public override TimeZoneInfo
            Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            TZConvert.GetTimeZoneInfo(reader.GetString());

        public override void Write(Utf8JsonWriter writer, TimeZoneInfo value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            
            writer.WriteStringValue(value.Id);
        }
    }
}