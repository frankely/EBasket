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
        private readonly IRequestHandler<GetOrdersQuery, IEnumerable<Order>> _requestHandler;

        public OrdersController(IRequestHandler<GetOrdersQuery, IEnumerable<Order>> requestHandler)
        {
            _requestHandler = requestHandler;
        }

        // GET api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            var result = await _requestHandler.HandleAsync(new GetOrdersQuery(), CancellationToken.None);

            return Ok(result);
        }
    }
}