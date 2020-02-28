using System;
using customer_api.Models;
using System.Threading.Tasks;

namespace customer_api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerContext _context;

        public CustomerService(CustomerContext context)
        {
            _context = context;
        }

        public Customer GetCustomerById(long id)
        {
            var customer = new Customer();
            customer.CustomerId = id;
            customer.Firstname = "Anthony";
            customer.Lastname = "Ikeda";
            customer.EmailAddress = "anthony.ikeda@gmail.com";

            return customer;
        }

        public long SaveCustomer(Customer customer)
        {
            var custId = LongRandom(100000000000000000, 100000000000000050, new Random());
            customer.CustomerId = custId;
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return custId;
        }

        long LongRandom(long min, long max, Random rand)
        {
            long result = rand.Next((Int32)(min >> 32), (Int32)(max >> 32));
            result = (result << 32);
            result = result | (long)rand.Next((Int32)min, (Int32)max);
            return result;
        }
    }
}