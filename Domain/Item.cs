using System;

namespace EBasket.Domain
{
    public class Item
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}