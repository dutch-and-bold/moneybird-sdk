using System;
using NodaMoney;

namespace DutchAndBold.MoneybirdSdk.Domain.Models.AdministrationAggregate
{
    public class Administration : MoneybirdEntityBase
    {
        /// <summary>
        /// Administration id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Administration name.
        /// </summary>
        public string Name { get; set; }

        /**
         * 2-char language code (eg: nl).
         */
        public string Language { get; set; }

        /// <summary>
        /// ISO 4217 currency Code.
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// ISO 3166-1 alpha-2 Country Code.
        /// In all capitals (eg: NL).
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// IANA Timezone.
        /// </summary>
        public TimeZoneInfo TimeZone { get; set; }
    }
}