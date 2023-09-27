using AutoMapper;
using Ecommerce.Models.APIModels;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.UtilityModels;
using Ecommerce.Services.Abstractions.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        ICustomerService _customerService;
        IMapper _mapper;

        public ClientsController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]CustomerSearchCriteria criteria)
        {
            var customers = _customerService.Search(criteria);

            if(customers==null)
            {
                var responseObj = new {
                    StatusCode = StatusCodes.Status204NoContent,
                    ErrorMessage = "No Data Found"

                };
                return NotFound(responseObj);
                
            }

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _customerService.GetById(id);

            if(customer==null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerCreate model)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(model);
                var isAdded = _customerService.Add(customer);

                if (isAdded)
                {
                    return Ok(); 
                }

                return BadRequest("Customer could not be saved!");
            }

            return BadRequest(ModelState);
        }


    }
}
