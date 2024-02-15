using API_project.Model;
using API_project.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_customerService.GetCustomerById(id));
        }

        //
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            var createdCustomer = _customerService.CreateCustomer(customer);
            return CreatedAtAction(nameof(Get), new { id = createdCustomer.CustomerId }, createdCustomer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(string id, [FromBody] Customer customer)
        {
            var updatedCustomer = _customerService.UpdateCustomer(customer);
            if (updatedCustomer == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(string id)
        {
            _customerService.DeleteCustomer(id);
            return NoContent();
        }

        // Added action for joined query
      //  [HttpGet("{customerId}/products")]
        //public IActionResult GetProductsForCustomer(string customerId)
        // {
        // var products = _customerService.GetProductsByCustomer(customerId);
        //    return Ok(products);
        // }
        //
    
    }
}


