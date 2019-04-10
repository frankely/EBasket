using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using EBasket.Application;
using EBasket.Application.Core;
using EBasket.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace EBasket.WebApi.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private const string  CustomerIdHeaderName = "X-Customer-Id";
        private readonly ICommandHandler<PlaceOrderCommand> _placeOrderCommandHandler;
        private readonly IQueryHandler<GetOrdersSinceQuery, IEnumerable<OrderReadModel>> _getOrdersSinceQueryHandler;

        public OrdersController(ICommandHandler<PlaceOrderCommand> placeOrderCommandHandler,IQueryHandler<GetOrdersSinceQuery, IEnumerable<OrderReadModel>> getOrdersSinceQueryHandler)
        {
            _placeOrderCommandHandler = placeOrderCommandHandler;
            _getOrdersSinceQueryHandler = getOrdersSinceQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery][Required]DateTime since, string status)
        {
            var customerId = Request.Headers[CustomerIdHeaderName];

            if (string.IsNullOrWhiteSpace(customerId))
            {
                return BadRequest($"Missing header '{CustomerIdHeaderName}'");
            }

            var result = await _getOrdersSinceQueryHandler.ExecuteAsync(new GetOrdersSinceQuery
            {
                Status = status,
                CustomerId = customerId,
                Since = since.Date
            });

            return Ok(result);
        }
    }
}