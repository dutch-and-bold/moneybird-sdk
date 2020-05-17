using System;
using System.Linq;
using DutchAndBold.MoneybirdSdk.Domain.Query;

namespace DutchAndBold.MoneybirdSdk.Extensions
{
    public static class MoneybirdQueryExtensions
    {
        /// <summary>
        /// Stringifies an <see cref="IMoneybirdQuery"/>.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Throws when query is null.</exception>
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