namespace Loosely_Coupled_Systems_Domain_Events_Examples_API.Domain_Events.EventHandlers
{
    public class OrderEventArgs : EventArgs
    {
        public OrderEventArgs(Order order)
        {
            Order = order;
        }

        public Order Order { get; }
    }
}
