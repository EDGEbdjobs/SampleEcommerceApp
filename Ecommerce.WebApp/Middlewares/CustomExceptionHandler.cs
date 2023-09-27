namespace Ecommerce.WebApp.Middlewares
{
    public class CustomExceptionHandler
    {
        RequestDelegate _next;
        ILogger<CustomExceptionHandler> _logger; 

        public CustomExceptionHandler(RequestDelegate requestDelegate, ILogger<CustomExceptionHandler> logger)
        {
            _next = requestDelegate;
            _logger = logger;

        }


        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex);

                throw ex;

            }
        }
    }
}
