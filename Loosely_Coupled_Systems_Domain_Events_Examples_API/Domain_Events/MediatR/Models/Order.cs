using Loosely_Coupled_Systems_Domain_Events_Examples_API.Domain_Events.MediatR.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loosely_Coupled_Systems_Domain_Events_Examples_API.Domain_Events.MediatR.Models
{
    public class Order : Entity
    {
        public Guid Id { get; set; }
        [NotMapped]
        public List<object> OrderItems { get; set; }
        public void Complete()
        {
            RaiseDomainEvent(new OrderCreatedEvent()
            {
                OrderId = Id,
                OrderItems = OrderItems
            });
        }
    }
}
