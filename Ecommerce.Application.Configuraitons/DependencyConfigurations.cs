using Ecommerce.Database;
using Ecommerce.Repositories;
using Ecommerce.Repositories.Abstractions;
using Ecommerce.Services;
using Ecommerce.Services.Abstractions;
using Ecommerce.Services.Abstractions.Customers;
using Ecommerce.Services.Abstractions.Products;
using Ecommerce.Services.Customers;
using Ecommerce.Services.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Configuraitons
{
    public static  class DependencyConfigurations
    {
        public static void  Configure(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddTransient<ICustomerCategoryRepository, CustomerCategoryRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerCategoryService, CustomerCategoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository,OrderRepository>();
            services.AddScoped<ICustomerRepository>(service =>
            {
                int category = 1;
                if (category == 1)
                {
                    
                    var db = service.GetService<ApplicationDbContext>();
                    return new CustomerRepository(db);
                }
                else
                {
                    return new CustomerCloudRepository();
                }

            });
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                // string connectionString2 = "Server=(local); Database=SampleCommerceDB_2; Trusted_Connection=true;TrustServerCertificate=True;";
                string connectionString = "Server=(local); Database=SampleCommerceDB; Trusted_Connection=true;TrustServerCertificate=True;";
                option.UseSqlServer(connectionString);
            });
        }
    }
}
