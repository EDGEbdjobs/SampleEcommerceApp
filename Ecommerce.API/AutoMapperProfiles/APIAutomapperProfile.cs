using AutoMapper;
using Ecommerce.Models.APIModels;
using Ecommerce.Models.EntityModels;

namespace Ecommerce.API.AutoMapperProfiles
{
    public class APIAutomapperProfile : Profile
    {

        public APIAutomapperProfile()
        {
            CreateMap<CustomerCreate, Customer>();
        }

    }
}
