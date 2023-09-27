using Ecommerce.Models.EntityModels;
using Ecommerce.Models.UtilityModels;
using Ecommerce.Repositories.Abstractions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Abstractions
{

    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetById(int id);
        ICollection<Customer> Search(CustomerSearchCriteria searchCriteria);
        
    }
}
