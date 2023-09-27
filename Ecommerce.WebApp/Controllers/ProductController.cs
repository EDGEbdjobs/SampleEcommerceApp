using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstractions;
using Ecommerce.WebApp.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApp.Controllers
{
    [LogActionFilter]
    public class ProductController : Controller
    {
        IProductRepository _productRepository;
        ILogger _logger;
        
        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger)
        {
            _productRepository = productRepository; 
            _logger = logger;
            
        }
        // GET: ProductController

        [SampleActionFilter]
        public ActionResult Index()
        {
            try
            {
                _logger.LogDebug("Logging Debug...");
                _logger.LogInformation("Logging Information...");
                _logger.LogWarning("Logging Warning...");
                _logger.LogError("Logging Error...");
                _logger.LogCritical("Logging Critical...");

                HttpContext.Session.SetString("Product", "User12345859");

                var products = _productRepository.GetAll();
                return View(products);
            }
            catch(Exception ex)
            {
                throw new Exception("Error Occurred in Product Controller",ex); 
            }
          
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var sessionData = HttpContext.Session.GetString("Product");

            _logger.LogInformation($"Session Data: {sessionData} ");

            var product = _productRepository.GetById(id);
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var isSuccess = _productRepository.Add(product);
                    if (isSuccess)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    
                }

                return View(product);
              
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
