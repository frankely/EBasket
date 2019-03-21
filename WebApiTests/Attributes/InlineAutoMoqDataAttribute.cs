using AutoFixture.Xunit2;
using Xunit;
using Xunit.Sdk;

namespace EBasket.WebApiTests.Attributes
{
    public class InlineAutoMoqDataAttribute : CompositeDataAttribute
    {
        public InlineAutoMoqDataAttribute(params object[] values)
            : base(
                new DataAttribute[] { 
                    new InlineDataAttribute(values),
                    new AutoMoqDataAttribute() })
        {
        }
    }
}