using Ecommerce.Database;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.WebApp.Middlewares
{
    public static class ApplicationDbContextFactory
    {

        private static string _connectionString;

        public static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static void ResetConnectionString()
        {
            _connectionString = null;
        }

        public static ApplicationDbContext CreateDbContext()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("Connection string not set. Make sure to set the connection string before creating the DbContext.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);

        }
    }
}
