using System;

namespace EBasket.Domain
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTimeOffset DeliveryDate { get; set; }
    }
}