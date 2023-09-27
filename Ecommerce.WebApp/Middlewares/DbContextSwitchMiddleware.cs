using Ecommerce.Database;
using Microsoft.EntityFrameworkCore.Internal;

namespace Ecommerce.WebApp.Middlewares
{
    public class DbContextSwitchMiddleware
    {
        private readonly RequestDelegate _next;

        public DbContextSwitchMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IDbContextSwitchService dbContextSwitchService)
        {

            var requrestString = context.Request.Query["version"];
            string version = null;
            string connectionString = null;

            string connectionString2 = "Server=(local); Database=SampleCommerceDB_2; Trusted_Connection=true;TrustServerCertificate=True;";
            string connectionString1 = "Server=(local); Database=SampleCommerceDB_1; Trusted_Connection=true;TrustServerCertificate=True;";

            if (requrestString.Any())
            {
                version = requrestString[0];
            }

            if(version == "1")
            {
                connectionString = connectionString1;
            }
            else if(version == "2")
            {
                connectionString = connectionString2;
            }
            if (connectionString != null)
            {
                var dbContext = context.RequestServices.GetRequiredService<ApplicationDbContext>();
                ApplicationDbContextFactory.SetConnectionString(connectionString);
                dbContext =  ApplicationDbContextFactory.CreateDbContext(); 
            }



            // Call the next middleware in the pipeline.
            await _next(context);

            // Optionally, you can reset the connection string after the request is processed.
            ApplicationDbContextFactory.ResetConnectionString();
        }
    }
}
