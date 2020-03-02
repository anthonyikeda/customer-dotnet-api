using customer_api.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace customer_api.Services
{
    public interface ICustomerService
    {
        Customer GetCustomerById(long id);
        long SaveCustomer(Customer customer);

        void DeleteCustomer(long customerId);

        List<Customer> FindAll();
    }
}