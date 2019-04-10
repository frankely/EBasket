using System;
using AutoFixture.Xunit2;
using EBasket.Domain;
using Xunit;

namespace EBasket.UnitTests.Domain
{
    public class OrderTests
    {
        [Theory]
        [AutoData]
        public void Given_An_Order_Is_Placed_Then_Its_Status_Should_Be_Placed(string customerId)
        {
            var sut = Order.Place(customerId);
            
            Assert.Equal(OrderStatus.Placed, sut.Status);
        }

        [Theory]
        [AutoData]
        public void Given_An_Order_Is_Placed_It_Should_Have_An_Order_Id(string customerId)
        {
            var sut = Order.Place(customerId);
            
            Assert.NotEqual(Guid.Empty,sut.OrderId);
        }

        [Theory]
        [AutoData]
        public void Given_An_Order_Is_Placed_Customer_Ids_Should_Match(string expectedCustomerId)
        {
            var sut = Order.Place(expectedCustomerId);
            
            Assert.Equal(expectedCustomerId,sut.CustomerId);
        }
    }
}