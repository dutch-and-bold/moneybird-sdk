using System;
using System.Linq;
using DutchAndBold.MoneybirdSdk.Domain.Query;

namespace DutchAndBold.MoneybirdSdk.Extensions
{
    public static class MoneybirdQueryExtensions
    {
        public static string ToQueryString(this IMoneybirdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var queryString = query.GetType()
                .GetProperties()
                .Where(p => p.GetValue(query) != null)
                .Aggregate(
                    "?",
                    (c, p) =>
                        $"{c}{p.Name.PascalToSnakeCase()}={p.GetValue(query)}&")
                .TrimEnd('&');

            return queryString == "?" ? "" : queryString;
        }
    }
}