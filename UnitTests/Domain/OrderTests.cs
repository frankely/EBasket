using EBasket.Domain;
using Xunit;

namespace EBasket.UnitTests.Domain
{
    public class OrderTests
    {
        [Fact]
        public void Given_A_Order_Is_Placed_Then_Its_Status_Should_Be_Placed()
        {
            var customerId = "12346";
            var sut = Order.Place(customerId);
            
            Assert.Equal(OrderStatus.Placed, sut.Status);
        }
    }
}