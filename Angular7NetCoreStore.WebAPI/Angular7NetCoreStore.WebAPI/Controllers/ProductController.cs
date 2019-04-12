using Angular7NetCoreStore.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Angular7NetCoreStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        // GET: api/Product
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productAppService.GetAll());
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_productAppService.GetById(id));
        }
    }
}
