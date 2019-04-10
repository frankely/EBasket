using System;
using EBasket.Domain;

namespace EBasket.Application.Models
{
    public class OrderReadModel
    {
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public DateTimeOffset PlacedDate { get; set; }
        public OrderStatus Status { get; set; }
    }
}