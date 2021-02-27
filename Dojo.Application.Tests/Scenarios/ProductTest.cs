using Dojo.Application.Tests.Fixtures;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Dojo.Application.Tests.Scenarios
{
    public class ProductTest
    {
        private readonly TestContext _testContext;
        public ProductTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Product_GetAll_ReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/products");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Product_GetById_ProductReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/products/3");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Product_GetById_ReturnsNoContent()
        {
            var response = await _testContext.Client.GetAsync("/products/XXX");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Product_GetById_CorrectContentType()
        {
            var response = await _testContext.Client.GetAsync("/products/3");
            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
        }
    }
}
