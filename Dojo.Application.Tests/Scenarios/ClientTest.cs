using Dojo.Application.Tests.Fixtures;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Dojo.Application.Tests.Scenarios
{
    public class ClientTest
    {
        private readonly TestContext _testContext;
        public ClientTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Client_GetAll_ReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/clients");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Client_GetById_ClientReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/clients/5");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Client_GetById_ReturnsNoContent()
        {
            var response = await _testContext.Client.GetAsync("/clients/XXX");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Client_GetById_CorrectContentType()
        {
            var response = await _testContext.Client.GetAsync("/clients/5");
            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
        }
    }
}
