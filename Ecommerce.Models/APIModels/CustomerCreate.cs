using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.APIModels
{
    public class CustomerCreate
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }

        public int? CustomerCategoryId { get; set; }
    }
}
