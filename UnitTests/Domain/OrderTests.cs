using AutoFixture.Xunit2;
using EBasket.Domain;
using Xunit;

namespace EBasket.UnitTests.Domain
{
    public class OrderTests
    {
        [Theory]
        [AutoData]
        public void Given_A_Order_Is_Placed_Then_Its_Status_Should_Be_Placed(string customerId)
        {
            var sut = Order.Place(customerId);
            
            Assert.Equal(OrderStatus.Placed, sut.Status);
        }
    }
}