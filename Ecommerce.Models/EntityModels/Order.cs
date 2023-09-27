using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.EntityModels
{
    public class Order
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? CustomerId { get; set; }

        public Customer? Customer { get; set; }

        public DateTime? Date { get; set; }

        public ICollection<OrderItem>? OrderItems {  get; set; }

    }
}
