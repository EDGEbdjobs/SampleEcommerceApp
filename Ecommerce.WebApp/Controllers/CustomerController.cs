using AutoMapper;
using Ecommerce.Database;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.UtilityModels;
using Ecommerce.Services.Abstractions.Customers;
using Ecommerce.WebApp.Models;
using Ecommerce.WebApp.Models.CustomerList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.WebApp.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        ICustomerService _customerService;
        ICustomerCategoryService _customerCategoryService;
        RandomClass _random;
        IMapper _mapper;
        public CustomerController(ICustomerService customerService, ICustomerCategoryService customerCategoryService, RandomClass random, IMapper mapper)
        {
            _customerService = customerService;
            _customerCategoryService = customerCategoryService;
            _random = random;
            _mapper = mapper;
        }


        public IActionResult Index(CustomerSearchCriteria customerSearchCriteria)
        {
            
            var customers = _customerService.Search(customerSearchCriteria);

            ICollection<CustomerListItem> customerModels = customers.Select(c => new CustomerListItem()
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
            }).ToList();

            var customerListModel = new CustomerListViewModel();
            customerListModel.CustomerList = customerModels;

            return View(customerListModel);
        }


        public IActionResult Create()
        {

            CustomerCreate model = GetCustomerCreateModelwithCategories();

            return View(model);
        }

        private CustomerCreate GetCustomerCreateModelwithCategories()
        {
            var categories = _customerCategoryService.GetAll();

            var categorylistItems = categories.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name,
            });

            var model = new CustomerCreate();
            model.Categories = categorylistItems;
            return model;
        }

        [HttpPost]
        public IActionResult Create(CustomerCreate model)
        {

            if (ModelState.IsValid)
            {

                var customer = _mapper.Map<Customer>(model);


                //var customer = new Customer()
                //{
                //    Name = model.Name,
                //    Phone = model.Phone,
                //    Email = model.Email,
                //};
                //Database operations 
                bool isSuccess = _customerService.Add(customer);

                if (isSuccess)
                {
                    return RedirectToAction("Index");
                }

            }

            var createModel = GetCustomerCreateModelwithCategories();

            model.Categories = createModel.Categories;


            return View(model);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                ViewBag.Error = "Please provide valid id.";
                return View();
            }

            var customer = _customerService.GetById((int)id);

            if (customer == null)
            {
                ViewBag.Error = "Sorry, no customer found for this id.";
                return View();
            }

            var model = new CustomerEditVM()
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CustomerEditVM model)
        {
            if (ModelState.IsValid)
            {
                var customer = _customerService.GetById(model.Id);

                if (customer == null)
                {
                    ViewBag.Error = "Customer not found to update!";
                    return View(model);
                }

                 _mapper.Map(model, customer);

                //customer.Name = model.Name;
                //customer.Email = model.Email;
                //customer.Phone = model.Phone;

                bool isSuccess = _customerService.Update(customer);
                if (isSuccess)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

    }
}
