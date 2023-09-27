using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstractions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Abstractions
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
    }
}
