using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using customer_api.Models;
using customer_api.Services;

namespace customer_api.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class CustomerApiController : ControllerBase
    {
        private readonly ILogger<CustomerApiController> _logger;
        private readonly ICustomerService _service;


        public CustomerApiController(ILogger<CustomerApiController> logger, 
                ICustomerService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Customer customer)
        {
            long custId =  _service.SaveCustomer(customer);
            customer.CustomerId = custId;
            
            return CreatedAtAction(nameof(GetCustomer), new { customerId = custId }, customer);
        }

        [HttpGet]
        public List<Customer> getAllCustomers()
        {
            return _service.FindAll();
        }

        [HttpGet("{customerId}")]
        public Customer GetCustomer(long customerId)
        {
            return _service.GetCustomerById(customerId);
        }

        [HttpDelete("{customerId}")]
        public IActionResult deleteCustomer(long customerId)
        {
            _logger.LogDebug(String.Format("Attempting to delete customer {0}", customerId));

            try
            {
                _service.DeleteCustomer(customerId);
                return Accepted();
            } catch(ArgumentException e)
            {
                _logger.LogError("Customer not found", e);
                return BadRequest();
            }
            
        }
    }
}