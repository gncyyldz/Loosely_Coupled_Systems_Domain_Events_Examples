namespace Loosely_Coupled_Systems_Domain_Events_Examples_API.Domain_Events.MediatR
{
    public class OrderCreatedEvent : IDomainEvent
    {
        public Guid OrderId { get; set; }
        public List<object> OrderItems { get; set; }
    }
}
