using Ecommerce.Database;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstractions;
using Ecommerce.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class ProductRepository :BaseRepository<Product>, IProductRepository
    {
        ApplicationDbContext _db; 
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public Product GetById(int id)
        {
            return _db.Products.FirstOrDefault(c => c.Id == id);
        }

        public override ICollection<Product> GetAll()
        {
           
            return base.GetAll();
        }
    }
}
