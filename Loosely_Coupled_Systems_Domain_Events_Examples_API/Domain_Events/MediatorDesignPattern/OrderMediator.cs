namespace Loosely_Coupled_Systems_Domain_Events_Examples_API.Domain_Events.MediatorDesignPattern
{
    //Mediator Sınıfı
    public class OrderMediator : IOrderCompletedEvent
    {
        readonly List<IOrderCompletedEvent> _eventListener = new();
        public void Register(IOrderCompletedEvent @event)
        {
            _eventListener.Add(@event);
        }

        public void OrderCompleted(Order order)
        {
            _eventListener.ForEach(l => l.OrderCompleted(order));
            //Sipariş Tamamlandı...
            //...
        }
    }
}
