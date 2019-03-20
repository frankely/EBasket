using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EBasket.Application.Core;
using EBasket.Application.Queries;
using EBasket.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EBasket.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IRequestHandler<GetLatestDeliveredOrdersByCustomerQuery, IEnumerable<Order>> _requestHandler;

        public OrdersController(IRequestHandler<GetLatestDeliveredOrdersByCustomerQuery, IEnumerable<Order>> requestHandler)
        {
            _requestHandler = requestHandler;
        }
        // GET api/orders?customerId={customerId}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get([FromQuery]string customerId)
        {
            var result = await _requestHandler.HandleAsync(new GetLatestDeliveredOrdersByCustomerQuery
                {
                    CustomerId = Guid.Parse(customerId)
                },
                CancellationToken.None);

            return Ok(result);
        }
    }
}