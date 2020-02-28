using customer_api.Models;
using System.Threading.Tasks;

namespace customer_api.Services
{
    public interface ICustomerService
    {
        Customer GetCustomerById(long id);
        long SaveCustomer(Customer customer);
    }
}