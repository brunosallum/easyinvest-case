using Dojo.Domain.Services;
using Dojo.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Dojo.Application.Controllers
{
    [ApiController]
    [Route("orders")]
    public class PurchaseOrderController : ControllerBase
    {
        readonly IPurchaseOrderService _purchaseOrderService;

        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        [HttpGet]
        [Route("{purchaseOrderId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById([FromRoute] string purchaseOrderId)
        {
            var order = await _purchaseOrderService.GetByIdAsync(purchaseOrderId);
            if (order == null)
                return NoContent();

            return Ok(order);
        }

        [HttpPost]
        [Route("create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> CreatePurchaseOrder([FromBody] PurchaseOrderRequestViewModel purchaseOrder)
        {
            var result = await _purchaseOrderService.CreatePurchaseOrderAsync(purchaseOrder);
            return Created(string.Empty, result);
        }
    }
}
