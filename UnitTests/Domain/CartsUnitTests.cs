using System;
using AutoFixture.Xunit2;
using EBasket.Domain;
using EBasket.Domain.ShoppingCart;
using Xunit;

namespace EBasket.UnitTests.Domain
{
    public class CartsUnitTests
    {
        [Fact]
        public void Given_Cart_Is_Created_Id_Should_Be_Assigned()
        {
            var sut = new Cart();
            
            Assert.NotEqual(Guid.Empty, sut.Id);
        }

        [Theory]
        [AutoData]
        public void Given_Item_Is_Added_To_Cart_It_Should_Be_Added_To_Items(Item item)
        {
            var sut = new Cart();
            
            sut.AddItem(item);
            
            Assert.NotEmpty(sut.Items);
        }
    }
}