using Ecommerce.Models.EntityModels;
using Ecommerce.Models.UtilityModels;
using Ecommerce.Repositories.Abstractions;
using Ecommerce.Repositories.Abstractions.Base;
using Ecommerce.Services.Abstractions.Customers;
using Ecommerce.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Customers
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        ICustomerRepository _customerRepository; 
        ICustomerCategoryRepository _categoryRepository;
        public CustomerService(ICustomerRepository repository, ICustomerCategoryRepository categoryRepository) : base(repository)
        {
            _customerRepository = repository;
            _categoryRepository = categoryRepository;
        }

        public override bool Add(Customer entity)
        {
            // logic implement 
             
            return _customerRepository.Add(entity);
        }

        public Customer GetById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public ICollection<Customer> Search(CustomerSearchCriteria searchCriteria)
        {
            return _customerRepository.Search(searchCriteria);
        }
    }
}
