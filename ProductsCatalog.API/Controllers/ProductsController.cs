using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsCatalog.Core;
using ProductsCatalog.Core.Models;
using ProductsCatalog.Services;

namespace ProductsCatalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var productServiceResult = _productService.GetAll();
            if (productServiceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(productServiceResult.Error);
            return Ok(productServiceResult.Result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductDataTransferObject product)
        {
            var productServiceResult = _productService.Add(product);
            if (productServiceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(productServiceResult.Error);
            return Ok(productServiceResult.Result);
        }
    }
}
