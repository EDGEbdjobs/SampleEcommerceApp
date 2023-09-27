using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstractions;
using Ecommerce.Repositories.Abstractions.Base;
using Ecommerce.Services.Abstractions;
using Ecommerce.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        IOrderRepository _repository; 
        public OrderService(IOrderRepository repository) : base(repository)
        {
            this._repository = repository;
        }
    }
}
