using System.Net;
using System.Threading.Tasks;
using EBasket.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace EBasket.WebApiTests
{
    public class OrdersControllerTests  : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public OrdersControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Fact]
        public async Task Given_Query_Parameter_Since_Is_Not_Provided_When_Calling_Get_Orders_It_Should_Throw_Bad_Request()
        {
            var client = _factory.CreateClient();
            
            var response = await client.GetAsync("/api/orders");
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}