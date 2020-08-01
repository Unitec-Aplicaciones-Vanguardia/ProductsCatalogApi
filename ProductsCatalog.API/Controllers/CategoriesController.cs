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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categoryServiceResult = _categoryService.GetAll();
            if (categoryServiceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(categoryServiceResult.Error);
            return Ok(categoryServiceResult.Result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(long id)
        {
            var categoryServiceResult = _categoryService.GetProductsByCategory(id);
            if (categoryServiceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(categoryServiceResult.Error);
            return Ok(categoryServiceResult.Result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoryDataTransferObject category)
        {
            var categoryServiceResult = _categoryService.Add(category);
            if (categoryServiceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(categoryServiceResult.Error);
            return Ok(categoryServiceResult.Result);
        }
    }
}
