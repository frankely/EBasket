using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace EBasket.WebApi.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Order> GetOrders([FromQuery][Required]DateTime since)
        {
            return new List<Order>();
        }
    }

    public class Order
    {
    }
}