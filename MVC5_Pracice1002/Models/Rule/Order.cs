using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_Pracice1002.Models
{
    [MetadataType(typeof(OrderMetaData))]
    public partial class Order
    {
    }

    public partial class OrderMetaData
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public Nullable<int> ClientId { get; set; }
        [Required]
        public Nullable<System.DateTime> OrderDate { get; set; }
        [Required]
        public Nullable<decimal> OrderTotal { get; set; }
        [Required]
        public string OrderStatus { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }

}