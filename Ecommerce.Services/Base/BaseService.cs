using Ecommerce.Repositories.Abstractions.Base;
using Ecommerce.Repositories.Base;
using Ecommerce.Services.Abstractions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Base
{
    public class BaseService<T> : IService<T> where T : class
    {
        IRepository<T> _repostiory;

        public BaseService(IRepository<T> repository)
        {
            _repostiory = repository;
        }
        public virtual bool Add(T entity)
        {
            return _repostiory.Add(entity);
        }

        public virtual bool AddRange(ICollection<T> entities)
        {
            return _repostiory.AddRange(entities);
        }

        public virtual bool Delete(T entity)
        {
            return _repostiory.Delete(entity);
        }

        public virtual ICollection<T> GetAll()
        {
            return _repostiory.GetAll();
        }

        public virtual bool Update(T entity)
        {
            return _repostiory.Update(entity);
        }

        public virtual bool UpdateRange(ICollection<T> entity)
        {
            return _repostiory.UpdateRange(entity);
        }
    }
}
