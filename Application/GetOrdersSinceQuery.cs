using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EBasket.Application.Core;
using EBasket.Application.Models;

namespace EBasket.Application
{
    public class GetOrdersSinceQuery : IQuery<IEnumerable<OrderReadModel>>
    {
        public string CustomerId { get; set; }
        
        public DateTimeOffset Since { get; set; }
        
        public string Status { get; set; }

        public class Handler : IQueryHandler<GetOrdersSinceQuery, IEnumerable<OrderReadModel>>
        {
            public Task<IEnumerable<OrderReadModel>> ExecuteAsync(GetOrdersSinceQuery request)
            {
                throw new NotImplementedException();
            }
        }
    }
}