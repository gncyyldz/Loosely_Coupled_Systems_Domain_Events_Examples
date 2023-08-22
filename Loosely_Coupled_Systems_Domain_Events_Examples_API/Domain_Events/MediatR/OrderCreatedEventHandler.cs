using MediatR;

namespace Loosely_Coupled_Systems_Domain_Events_Examples_API.Domain_Events.MediatR
{
    public class OrderCreatedEventHandler : INotificationHandler<OrderCreatedEvent>
    {
        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            //Olayı işleyecek kodlar...
            Console.WriteLine($"Yeni sipariş verildi... {notification.OrderId}");
            return Task.CompletedTask;
        }
    }
}
