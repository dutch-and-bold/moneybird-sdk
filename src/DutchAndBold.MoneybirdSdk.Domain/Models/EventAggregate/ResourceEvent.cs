using System;

namespace DutchAndBold.MoneybirdSdk.Domain.Models.EventAggregate
{
    public class ResourceEvent
    {
        public string AdministrationId { get; set; }
        public string UserId { get; set; }
        public ResourceEventAction Action { get; set; }
        public string LinkEntityId { get; set; }
        public string LinkEntityType { get; set; }
        public ResourceEventData Data { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}