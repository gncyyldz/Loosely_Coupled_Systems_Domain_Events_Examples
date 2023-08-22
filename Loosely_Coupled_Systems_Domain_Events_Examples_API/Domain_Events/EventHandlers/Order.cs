namespace Loosely_Coupled_Systems_Domain_Events_Examples_API.Domain_Events.EventHandlers
{
    public class Order
    {
        //Domain Event
        public event EventHandler<OrderEventArgs> OrderCompleted;

        //Event Tetikleme Metodu
        public virtual void OnOrderCompleted(OrderEventArgs e)
        {
            OrderCompleted(this, e);
        }

        //Sipariş Tamamlandığında Bu Metot Çağrılabilir
        public void CompleteOrder()
        {
            //Sipariş Tamamlandı...
            //...

            //Domain Event'i Tetikleme
            OnOrderCompleted(new OrderEventArgs(this));
        }
    }
}
