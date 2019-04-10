using System;
using System.Collections.Generic;

namespace EBasket.Domain
{
    public class Order
    {
        public DateTimeOffset DatePlaced { get; private set;  }
        public Guid OrderId { get; private set; }
        public OrderStatus Status { get; private set; }
        public string CustomerId { get; private set; }

        private Order()
        {
            
        }

        public static Order Place(string customerId)
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