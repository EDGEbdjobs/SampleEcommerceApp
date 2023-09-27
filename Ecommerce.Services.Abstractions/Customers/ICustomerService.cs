using Ecommerce.Models.EntityModels;
using Ecommerce.Models.UtilityModels;
using Ecommerce.Services.Abstractions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Abstractions.Customers
{
    public interface ICustomerService : IService<Customer>
    {
        Customer GetById(int id);
        ICollection<Customer> Search(CustomerSearchCriteria searchCriteria);
    }
}
