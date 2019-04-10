using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using EBasket.Application;
using EBasket.Application.Core;
using EBasket.Application.Models;
using EBasket.WebApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace EBasket.WebApiTests
{
    public class OrdersControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public OrdersControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [AutoData]
        public async Task
            Given_Query_Parameter_Since_Is_Not_Provided_When_Calling_Get_Orders_It_Should_Throw_Bad_Request(
                Guid customerId)
        {
            var mockedQueryHandler = new Mock<IQueryHandler<GetOrdersSinceQuery, IEnumerable<OrderReadModel>>>();
            var mockedCommandHandler = new Mock<ICommandHandler<PlaceOrderCommand>>();

            var client = _factory
                .WithWebHostBuilder(host =>
                {
                    host.ConfigureServices(services =>
                    {
                        services.AddScoped(provider => mockedQueryHandler.Object);
                        services.AddScoped(provider => mockedCommandHandler.Object);
                    });
                })
                .CreateClient();

            client.DefaultRequestHeaders.Add("X-Customer-Id", customerId.ToString());

            var response = await client.GetAsync("/api/orders");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [AutoMoqData]
        public async Task Given_Customer_Id_Header_Is_Not_Provided_It_Should_Throw_Bad_Request(DateTime since,
            Mock<IQueryHandler<GetOrdersSinceQuery, IEnumerable<OrderReadModel>>> mockedQueryHandler,
            Mock<ICommandHandler<PlaceOrderCommand>> mockedCommandHandler)
        {
            var client = _factory
                .WithWebHostBuilder(host =>
                {
                    host.ConfigureServices(services =>
                    {
                        services.AddScoped(provider => mockedQueryHandler.Object);
                        services.AddScoped(provider => mockedCommandHandler.Object);
                    });
                })
                .CreateClient();


            var response = await client.GetAsync($"/api/orders?since={since}");
            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("Missing header 'X-Customer-Id'", content);
        }

        [Theory]
        [AutoMoqData]
        public async Task Given_Request_Is_Valid_And_There_Are_No_Orders_Matching_Criteria_It_Should_Return_Empty_List(
            Mock<IQueryHandler<GetOrdersSinceQuery, IEnumerable<OrderReadModel>>> mockedQueryHandler,
            Mock<ICommandHandler<PlaceOrderCommand>> mockedCommandHandler)
        {
            var fixture = new Fixture();

            var expectedOrders = fixture
                .CreateMany<OrderReadModel>(0);

            var since = fixture.Create<DateTime>();

            mockedQueryHandler
                .Setup(m => m.ExecuteAsync(It.IsAny<GetOrdersSinceQuery>()))
                .ReturnsAsync(expectedOrders);

            var client = _factory
                .WithWebHostBuilder(host =>
                {
                    host.ConfigureServices(services =>
                    {
                        services.AddScoped(provider => mockedQueryHandler.Object);
                        services.AddScoped(provider => mockedCommandHandler.Object);
                    });
                })
                .CreateClient();


            var customerId = fixture
                .Create<Guid>()
                .ToString();

            client.DefaultRequestHeaders.Add("X-Customer-Id", customerId);

            var response = await client.GetAsync($"/api/orders?since={since}");
            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("[]", content);
        }

        [Theory]
        [AutoMoqData]
        public async Task Given_Request_Is_Valid_And_There_Are_Orders_Matching_Criteria_It_Should_Return_Those_Orders(
            Mock<IQueryHandler<GetOrdersSinceQuery, IEnumerable<OrderReadModel>>> mockedQueryHandler,
            Mock<ICommandHandler<PlaceOrderCommand>> mockedCommandHandler, List<OrderReadModel> expectedOrders,
            DateTime since, Guid customerId)
        {
            var expectedResultInJson = JsonConvert.SerializeObject(expectedOrders, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            mockedQueryHandler
                .Setup(m => m.ExecuteAsync(It.IsAny<GetOrdersSinceQuery>()))
                .ReturnsAsync(expectedOrders);

            var client = _factory
                .WithWebHostBuilder(host =>
                {
                    host.ConfigureServices(services =>
                    {
                        services.AddScoped(provider => mockedQueryHandler.Object);
                        services.AddScoped(provider => mockedCommandHandler.Object);
                        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
                    });
                })
                .CreateClient();

            client.DefaultRequestHeaders.Add("X-Customer-Id", customerId.ToString());

            var response = await client.GetAsync($"/api/orders?since={since}");
            var actualResult = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual("[]", actualResult);
            Assert.Equal(expectedResultInJson, actualResult);
        }
    }
}