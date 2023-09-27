using Ecommerce.Models.EntityModels;
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
    public class CustomerCategoryService : BaseService<CustomerCategory>, ICustomerCategoryService
    {
        ICustomerCategoryRepository _customerCategoryRepository; 
        public CustomerCategoryService(ICustomerCategoryRepository repository) : base(repository)
        {
            _customerCategoryRepository = repository;
        }
    }
}
