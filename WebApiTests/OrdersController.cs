using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using EBasket.Application.Core;
using EBasket.Application.Queries;
using EBasket.Domain;
using EBasket.WebApi;
using EBasket.WebApiTests.Attributes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace EBasket.WebApiTests
{
    public class OrdersControllerIntegrationTests 
    {
        [Theory]
        [AutoMoqData]
        public async Task Given_There_Are_No_Orders_It_Should_Return_200_Ok(Mock<IRequestHandler<GetOrdersQuery, IEnumerable<Order>>> mockedRequestHandler)
        {
            mockedRequestHandler
                .Setup(m => m.HandleAsync(It.IsAny<GetOrdersQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Order>());
            
            var builder = new WebHostBuilder()
                .ConfigureServices(services =>
                    {
                        services.AddTransient(p => mockedRequestHandler.Object);
                    })
                .UseStartup<Startup>();

            var testServer = new TestServer(builder);

            var client = testServer.CreateClient();

            var response = await client.GetAsync($"api/orders");
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}