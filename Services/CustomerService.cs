using System;
using System.Linq;
using customer_api.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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

        public void DeleteCustomer(long customerId)
        {
            Customer customer = _context.Customers.Find(customerId);

            if(customer == null) {
                throw new ArgumentException(String.Format("Customer not found with id {0}", customerId));
            } else {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public List<Customer> FindAll()
        {
            return _context.Customers.ToList();
        }

    }
}