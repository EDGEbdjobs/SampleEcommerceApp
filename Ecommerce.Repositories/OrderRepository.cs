using Ecommerce.Database;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstractions;
using Ecommerce.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        ApplicationDbContext _db; 
        public OrderRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }
    }
}
