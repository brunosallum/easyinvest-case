using Dojo.Domain.Services;
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
    [Route("products")]
    public class ProductController : ControllerBase
    {
        readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAllAsync();
            if (products == null)
                return NoContent();

            return Ok(products);
        }

        [HttpGet]
        [Route("{productId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById([FromRoute] string productId)
        {
            var product = await _productService.GetByIdAsync(productId).ConfigureAwait(false);
            if (product == null)
                return NoContent();

            return Ok(product);
        }
    }
}
