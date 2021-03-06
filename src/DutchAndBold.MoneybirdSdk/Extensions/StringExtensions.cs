using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace DutchAndBold.MoneybirdSdk.Extensions
{
    internal static class StringExtensions
    {
        /// <summary>
        /// Converts string from 'PascalCase' to 'snake_case'.
        /// </summary>
        /// <param name="pascalCaseString">String in 'PascalCase'</param>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "CA1308")]
        public static string PascalToSnakeCase(this string pascalCaseString)
        {
            return string
                .Concat(pascalCaseString.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x : x.ToString()))
                .ToLowerInvariant();
        }
    }
}