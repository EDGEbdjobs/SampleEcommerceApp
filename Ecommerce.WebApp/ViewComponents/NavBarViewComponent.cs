using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApp.ViewComponents
{
    
    public class NavBar : ViewComponent
    {
        public NavBar()
        {
           
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
