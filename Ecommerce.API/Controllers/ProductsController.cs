using Ecommerce.Models.EntityModels;
using Ecommerce.Services.Abstractions.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }
        public ICollection<Product> Get()
        {
            return _productService.GetAll(); 
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            if (ModelState.IsValid)
            {
                var succeed = _productService.Add(product);
                if(succeed)
                {
                    return Ok(product);
                }
            }

            return BadRequest("Product Could not be saved!");


        }

    }
}
