using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5_Pracice1002.Models
{
    public class ProductBatchUpdateViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Decimal Stock { get; set; }
    }
}