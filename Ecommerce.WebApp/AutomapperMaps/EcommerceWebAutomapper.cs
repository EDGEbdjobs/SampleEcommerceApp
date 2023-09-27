using AutoMapper;
using Ecommerce.Models.EntityModels;
using Ecommerce.WebApp.Models;

namespace Ecommerce.WebApp.AutomapperMaps
{
    public class EcommerceWebAutomapper : Profile
    {
        public EcommerceWebAutomapper()
        {
            CreateMap<CustomerCreate, Customer>();
            CreateMap<Customer, CustomerCreate>();

            CreateMap<CustomerEditVM, Customer>();

        }
    }
}
