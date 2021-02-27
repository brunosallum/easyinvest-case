using Dojo.Application.Tests.Fixtures;
using Dojo.Domain.Entities.PurchaseOrder;
using Dojo.Domain.ViewModels;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Dojo.Application.Tests.Scenarios
{
    public class PurchaseOrderTest
    {
        private readonly TestContext _testContext;

        public PurchaseOrderTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task PurchaseOrder_GetById_PurchaseOrderReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/orders/00d3e59c-ab7c-4689-9c86-dbb3e35d2e55");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task PurchaseOrder_Create_PurchaseOrderReturnsCreatedResponse()
        {

            var payload = new PurchaseOrderRequestViewModel
            {
                ClientId = "2",
                ProductId = "3",
                RequestedAmount = 4,
                ValidationResult = { }
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PostAsync("/orders/create", content);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
