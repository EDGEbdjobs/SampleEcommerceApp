﻿using Ecommerce.Repositories.Abstractions.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Base
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        DbContext _db; 
        public BaseRepository(DbContext db)
        {
            _db = db; 
        }


        private DbSet<T> Table
        {
            get
            {
               return _db.Set<T>();
            }
        }


        public bool Add(T entity)
        {
            Table.Add(entity);
           return  _db.SaveChanges()>0;
        }

        public bool AddRange(ICollection<T> entities)
        {
            Table.AddRange(entities);
            return _db.SaveChanges()>0;
        }

        public bool Delete(T entity)
        {
           Table.Remove(entity);
            return _db.SaveChanges()>0;
        }

        public virtual ICollection<T> GetAll()
        {
            return Table.ToList();
        }

        public bool Update(T entity)
        {
            Table.Update(entity);
            return  _db.SaveChanges() > 0;
        }

        public bool UpdateRange(ICollection<T> entity)
        {
           Table.UpdateRange(entity);
            return _db.SaveChanges() > 0;
        }
    }
}
