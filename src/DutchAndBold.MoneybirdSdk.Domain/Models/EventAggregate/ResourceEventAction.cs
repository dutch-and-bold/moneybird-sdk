using System.Runtime.Serialization;

namespace DutchAndBold.MoneybirdSdk.Domain.Models.EventAggregate
{
    public enum ResourceEventAction
    {
        [EnumMember(Value = "contact_created")]
        ContactCreated = 0,
    }
}