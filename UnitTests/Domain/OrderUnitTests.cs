using AutoFixture.Xunit2;
using EBasket.Domain;
using Xunit;

namespace EBasket.UnitTests.Domain
{
    public class OrderUnitTests
    {
        [Theory]
        [AutoData]
        public void Given_Item_Is_Valid_When_Adding_To_Order_It_Should_Be_Added_To_Collection(Item item)
        {
            var sut = new Order();

            sut.AddItem(item);
            
            Assert.NotEmpty(sut.Items);
        }
    }
}