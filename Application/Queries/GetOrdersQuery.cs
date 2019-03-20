using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EBasket.Application.Core;
using EBasket.Domain;

namespace EBasket.Application.Queries
{
    public class GetOrdersQuery
    {
        internal sealed class
            Handler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
        {
            public async Task<IEnumerable<Order>> HandleAsync(GetOrdersQuery query, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }      
    }
}