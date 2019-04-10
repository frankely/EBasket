using System;

namespace EBasket.Domain
{
    public class Order
    {
        public DateTimeOffset DatePlaced { get; private set;  }
        public Guid OrderId { get; private set; }
        public OrderStatus Status { get; private set; }

        private Order()
        {
            
        }

        public static Order Place(string customerId)
        {
            return null;
        }
        
    }
}