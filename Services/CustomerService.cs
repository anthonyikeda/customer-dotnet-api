using System;
using customer_api.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace customer_api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerContext _context;

        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ILogger<CustomerService> logger, CustomerContext context)
        {
            _logger = logger;
            _context = context;
        }

        public Customer GetCustomerById(long id)
        {
            var cust = _context.Customers.Find(id);
            return cust;
        }

        public long SaveCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            _logger.Log(LogLevel.Information, "Id: " + customer.CustomerId);
            return customer.CustomerId;
        }

    }
}