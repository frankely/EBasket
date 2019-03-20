using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EBasket.Application.Core;
using EBasket.Domain;

namespace EBasket.Application.Queries
{
    public class GetLatestDeliveredOrdersByCustomerQuery
    {
        public Guid CustomerId { get; set; }

        internal sealed class
            Handler : IRequestHandler<GetLatestDeliveredOrdersByCustomerQuery, IEnumerable<Order>>
        {
            public async Task<IEnumerable<Order>> HandleAsync(GetLatestDeliveredOrdersByCustomerQuery query, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }      
    }
}