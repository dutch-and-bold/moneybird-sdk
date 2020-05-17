namespace DutchAndBold.MoneybirdSdk.Domain.Models
{
    public abstract class MoneybirdEntityBase : IMoneybirdEntity
    {
        public string? Id { get; set; }
    }
}