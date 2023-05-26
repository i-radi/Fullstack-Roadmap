using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.If.Sample.Models
{
    public class ProductSearchAndSortModel
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public long ProductTypeId { get; set; }
        public long CategoryId { get; set; }
        public long SortBy { get; set; }
    }
}
