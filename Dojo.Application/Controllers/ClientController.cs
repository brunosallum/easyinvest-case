
using Dojo.Domain.Services;
using Dojo.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Dojo.Application.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientController : ControllerBase
    {
        readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Route("")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get()
        {
            var clients = await _clientService.GetAllAsync();
            if (clients == null)
                return NoContent();

            return Ok(clients);
        }

        [HttpGet]
        [Route("{clientId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById([FromRoute] string clientId)
        {
            var client = await _clientService.GetByIdAsync(clientId).ConfigureAwait(false);
            if (client == null)
                return NoContent();

            return Ok(client);
        }
    }
}
