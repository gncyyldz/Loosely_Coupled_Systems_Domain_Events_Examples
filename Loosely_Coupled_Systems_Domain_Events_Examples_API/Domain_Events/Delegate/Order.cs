namespace Loosely_Coupled_Systems_Domain_Events_Examples_API.Domain_Events.Delegate
{
    public class Order
    {
        //Domain Event Delegate
        public delegate void OrderCompletedEventHandler();

        //Domain Event
        public event OrderCompletedEventHandler OrderCompleted;

        //Event Tetikleme Metodu
        public virtual void OnOrderCompleted()
        {
            OrderCompleted();
        }

        //Sipariş Tamamlandığında Bu Metot Çağrılabilir
        public void CompleteOrder()
        {
            //Sipariş Tamamlandı...
            //...

            //Domain Event'i Tetikle
            OnOrderCompleted();
        }
    }
}
