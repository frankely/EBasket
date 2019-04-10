using System;
using EBasket.Domain;
using Xunit;

namespace EBasket.UnitTests.Domain
{
    public class CustomerIdTests
    {
        [Theory]
        [InlineData("1")]
        [InlineData("63aaf294-945c-4642-bf94-27ee1567aede*")]
        public void Given_Customer_Id_Is_Not_A_Guid_It_Should_Throw_ArgumentException(string rawCustomerId)
        {
            Assert.Throws<ArgumentException>(() => { new CustomerId(rawCustomerId); });
        }
    }
}