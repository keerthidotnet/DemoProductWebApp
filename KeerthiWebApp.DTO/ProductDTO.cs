using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeerthiWebApp.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> IsActive { get; set; }

    }
}
