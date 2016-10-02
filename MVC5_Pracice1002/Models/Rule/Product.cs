using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_Pracice1002.Models
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
    }

    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        //[Required(ErrorMessage ="產品名稱是必要欄位")]
        [至少為一個空白字元Attribute(ErrorMessage ="至少包含一個空白字元")]
        public string ProductName { get; set; }
        [Required]
        [Range(2, 99, ErrorMessage = "商品價格必須介於 2~99 之間")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Nullable<decimal> Price { get; set; }
        [Required]
        public Nullable<bool> Active { get; set; }
        [Required]
        public Nullable<decimal> Stock { get; set; }

        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}