using System;
using System.Collections.Generic;
using System.Linq;

namespace EBasket.Domain.ShoppingCart
{
    public class Cart
    {
        private readonly List<Item> _items = new List<Item>();
        public Guid Id { get; }

        public IEnumerable<Item> Items => _items.ToList();

        public Cart()
        {
            Id = Guid.NewGuid();
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }
    }
}