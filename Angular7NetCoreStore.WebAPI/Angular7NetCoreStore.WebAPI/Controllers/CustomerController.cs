using Angular7NetCoreStore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Angular7NetCoreStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        // GET: api/Customer
        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _customerAppService.GetAll();
            return Ok(customers);
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public string GetById(int id)
        {
            return "value";
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Customer/5
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
