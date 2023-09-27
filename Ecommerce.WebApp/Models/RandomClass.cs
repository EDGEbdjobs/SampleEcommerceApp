using Ecommerce.Repositories.Abstractions;

namespace Ecommerce.WebApp.Models
{
    public class RandomClass
    {
        ICustomerRepository _customerRepository;
        public RandomClass(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
    }
}
