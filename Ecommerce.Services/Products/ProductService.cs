using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstractions;
using Ecommerce.Repositories.Abstractions.Base;
using Ecommerce.Services.Abstractions.Products;
using Ecommerce.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Products
{
    public class ProductService : BaseService<Product>, IProductService
    {
        IProductRepository _productRepository; 
        public ProductService(IProductRepository repository) : base(repository)
        {
            this._productRepository = repository;
        }

        public Product GetById(int id)
        {
            return this._productRepository.GetById(id); 
        }
    }
}
