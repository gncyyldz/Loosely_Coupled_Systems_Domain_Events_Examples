namespace Loosely_Coupled_Systems_Domain_Events_Examples_API.Domain_Events.MediatorDesignPattern
{
    public class EmailService : IOrderCompletedEvent
    {
        public void OrderCompleted(Order order)
        {
            Console.WriteLine("Email gönderildi.");
        }
    }
}
