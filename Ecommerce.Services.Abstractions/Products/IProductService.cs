using Ecommerce.Models.EntityModels;
using Ecommerce.Services.Abstractions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Abstractions.Products
{
    public interface IProductService : IService<Product>
    {
        Product GetById(int id);
    }
}
