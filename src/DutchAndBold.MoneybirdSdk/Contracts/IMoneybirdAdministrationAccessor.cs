#nullable enable
namespace DutchAndBold.MoneybirdSdk.Contracts
{
    public interface IMoneybirdAdministrationAccessor
    {
        /// <summary>
        /// Gets the entity Id.
        /// </summary>
        public string? Id { get; set; }
    }
}