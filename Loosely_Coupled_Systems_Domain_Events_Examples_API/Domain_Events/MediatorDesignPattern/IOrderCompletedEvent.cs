namespace Loosely_Coupled_Systems_Domain_Events_Examples_API.Domain_Events.MediatorDesignPattern
{
    //Domain Event Interface
    public interface IOrderCompletedEvent
    {
        void OrderCompleted(Order order);
    }
}
