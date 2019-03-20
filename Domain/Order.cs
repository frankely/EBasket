using System;
using System.Collections.Generic;
using System.Linq;

namespace EBasket.Domain
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTimeOffset DeliveryDate { get; set; }

        public IReadOnlyCollection<Item> Items => _items.ToList();
        private readonly List<Item> _items = new List<Item>();

        public void AddItem(Item item)
        {
           _items.Add(item);
        }
    }
}