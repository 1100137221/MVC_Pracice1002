using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_Pracice1002.Models
{
    public class 至少為一個空白字元Attribute : DataTypeAttribute
    {
        public 至少為一個空白字元Attribute() : base(DataType.Text)
        {

        }

        public override bool IsValid(object value)
        {
            var str = (string)value;
            return str.Contains(" ");
        }

    }
}