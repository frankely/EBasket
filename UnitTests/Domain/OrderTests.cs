using System;
using System.Collections.Generic;
using EBasket.Domain;
using Xunit;

namespace EBasket.UnitTests.Domain
{
    public class OrderTests
    {
        [Theory]
        [MemberData(nameof(GetCustomerId))]
        public void Given_An_Order_Is_Placed_Then_Its_Status_Should_Be_Placed(CustomerId customerId)
        {
            var sut = Order.Place(customerId);

            Assert.Equal(OrderStatus.Placed, sut.Status);
        }

        [Theory]
        [MemberData(nameof(GetCustomerId))]
        public void Given_An_Order_Is_Placed_It_Should_Have_An_Order_Id(CustomerId customerId)
        {
            var sut = Order.Place(customerId);

            Assert.NotEqual(Guid.Empty, sut.OrderId);
        }

        [Theory]
        [MemberData(nameof(GetCustomerId))]
        public void Given_An_Order_Is_Placed_Customer_Ids_Should_Match(CustomerId customerId)
        {
            var sut = Order.Place(customerId);

            Assert.Equal(customerId, sut.CustomerId);
        }

        public static IEnumerable<object[]> GetCustomerId()
        {
            yield return new object[]
            {
                new CustomerId(Guid.NewGuid().ToString())
            };
        }
    }
}