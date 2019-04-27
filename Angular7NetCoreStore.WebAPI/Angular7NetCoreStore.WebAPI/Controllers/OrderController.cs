using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular7NetCoreStore.Application.Interfaces;
using Angular7NetCoreStore.Domain.Commands.Inputs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Angular7NetCoreStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderAppService _orderAppService;

        public OrderController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        // GET: api/Order
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Order/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Order
        [HttpPost]
        public IActionResult Post([FromBody]CreateOrderCommand createOrderCommand)
        {
            var commandResult = _orderAppService.AddOrder(createOrderCommand);
            if (commandResult.Success)
            {
                return Ok(commandResult);
            }

            return BadRequest(commandResult);
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
