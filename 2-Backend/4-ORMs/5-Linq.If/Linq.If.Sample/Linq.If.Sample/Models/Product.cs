using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.If.Sample.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ProductTypeId { get; set; }
        public long CategoryId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
