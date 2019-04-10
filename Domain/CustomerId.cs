using System;

namespace EBasket.Domain
{
    public class CustomerId
    {
        public Guid Value { get; private set; }

        public CustomerId(string customerId)
        {
            if (Guid.TryParse(customerId, out var outCustomerId))
            {
                Value = outCustomerId;
            }
            else
            {
                throw new ArgumentException($"{customerId} is not a valid {nameof(CustomerId)} value");
            }
        }
    }
}