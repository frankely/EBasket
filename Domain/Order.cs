using System;

namespace EBasket.Domain
{
    public class Order
    {
        public DateTimeOffset DatePlaced { get; private set;  }
        public Guid OrderId { get; private set; }
        public OrderStatus Status { get; private set; }
        public CustomerId CustomerId { get; private set; }

        private Order()
        {
            
        }

        public static Order Place(CustomerId customerId)
        {
            return new Order
            {
                Status = OrderStatus.Placed,
                OrderId = Guid.NewGuid(),
                CustomerId = customerId
            };
        }
        
    }
}