using System;

namespace DutchAndBold.MoneybirdSdk.Domain.Query
{
    public class MoneybirdQuery : IMoneybirdQuery
    {
        private uint? _perPage = 50;

        public uint? Page { get; set; } = 1;

        public uint? PerPage
        {
            get => _perPage;
            set
            {
                if (value > 100)
                {
                    throw new ArgumentException($"[{nameof(PerPage)}] Can't exceed 100");
                }

                _perPage = value;
            }
        }
    }
}