﻿using Ecommerce.Database;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.UtilityModels;
using Ecommerce.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        ApplicationDbContext _db;
        Guid Guid { get; set; }

        public CustomerRepository(ApplicationDbContext db)
        {
            _db = db; 
            Guid = Guid.NewGuid();
        }

        public bool Add(Customer Customer)
        {
            _db.Customers.Add(Customer);
            return _db.SaveChanges() > 0;
        }

        public bool AddRange(ICollection<Customer> Customers)
        {
            _db.Customers.AddRange(Customers);
            return _db.SaveChanges() > 0;
        }

        public bool Update(Customer Customer)
        {
            _db.Customers.Update(Customer);

            return _db.SaveChanges() > 0;
        }

        public bool UpdateRange(ICollection<Customer> Customers)
        {
            _db.Customers.UpdateRange(Customers);
            return _db.SaveChanges() > 0;
        }

        public bool Delete(Customer Customer)
        {
            _db.Customers.Remove(Customer);
            return _db.SaveChanges() > 0;
        }

        public Customer GetById(int id)
        {
            return _db.Customers.FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Customer> GetAll()
        {
            return _db.Customers.ToList();
        }

        public ICollection<Customer> Search(CustomerSearchCriteria searchCriteria)
        {
            var customers = _db.Customers.AsQueryable();

            if(!string.IsNullOrEmpty(searchCriteria.SearchText))
            {
                string searchText= searchCriteria.SearchText.ToLower();

                customers = customers.Where(c => c.Name.ToLower().Contains(searchText) 
                || c.Phone.ToLower().Contains(searchText) 
                || c.Email.ToLower().Contains(searchText));
            }


            if(searchCriteria != null && !string.IsNullOrEmpty(searchCriteria.Name))
            {
                customers = customers.Where(c=>c.Name.ToLower().Contains(searchCriteria.Name.ToLower()));
            }

            if (searchCriteria != null && !string.IsNullOrEmpty(searchCriteria.Phone))
            {
                customers = customers.Where(c => c.Phone.ToLower().Contains(searchCriteria.Phone.ToLower()));
            }

            if (searchCriteria != null && !string.IsNullOrEmpty(searchCriteria.Email))
            {
                customers = customers.Where(c => c.Email.ToLower().Contains(searchCriteria.Email.ToLower()));
            }

            

            int skipSize = (searchCriteria.CurrentPage-1) * searchCriteria.PageSize;

            return customers.Skip(skipSize).Take(searchCriteria.PageSize).ToList();



        }
    }
}
