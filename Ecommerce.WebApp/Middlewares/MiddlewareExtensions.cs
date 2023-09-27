using System.Runtime.CompilerServices;

namespace Ecommerce.WebApp.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static void UseDbContextSwitcher(this IApplicationBuilder app)
        {
            app.UseMiddleware<DbContextSwitchMiddleware>();
        }

        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionHandler>();
        }
    }
}
