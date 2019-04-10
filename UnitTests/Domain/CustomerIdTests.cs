using System;
using AutoFixture.Xunit2;
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
           var ex = Assert.Throws<ArgumentException>(() => { new CustomerId(rawCustomerId); });
           
           Assert.Equal($"{rawCustomerId} is not a valid {nameof(CustomerId)} value", ex.Message);
        }

        [Theory]
        [AutoData]
        public void Given_Raw_Customer_Id_Is_A_Valid_Guid_Value_Should_Match(Guid expectedCustomerId)
        {
            var rawCustomerId = expectedCustomerId.ToString();
            var sut = new CustomerId(rawCustomerId);
            
            Assert.Equal(expectedCustomerId, sut.Value);
        }
    }
}