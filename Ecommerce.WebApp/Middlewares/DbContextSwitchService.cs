namespace Ecommerce.WebApp.Middlewares
{
    public interface IDbContextSwitchService
    {
        string GetConnectionString();
        void SetConnectionString(string connectionString);
    }

    public class DbContextSwitchService : IDbContextSwitchService
    {
        private string _connectionString;
      
        public DbContextSwitchService()
        {
           
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }

        public void SetConnectionString(string connectionString)
        {
           _connectionString = connectionString;
        }

     
    }
}
