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
    public class CustomerCategoryRepository : BaseRepository<CustomerCategory>, ICustomerCategoryRepository
    {
        ApplicationDbContext _db; 
        public CustomerCategoryRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public ICollection<CustomerCategory> GetAll()
        {
            return _db.CustomerCategories.ToList();
        }
    }
}
