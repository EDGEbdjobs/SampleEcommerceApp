using Ecommerce.Models.EntityModels;
using Ecommerce.Models.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Database
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product>  Products { get; set; }
        
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<CustomerCategory> CustomerCategories { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = "Server=(local); Database=SampleCommerceDB; Trusted_Connection=true;TrustServerCertificate=True;";

            //optionsBuilder.UseSqlServer(connectionString);
        }


        
    }
}
