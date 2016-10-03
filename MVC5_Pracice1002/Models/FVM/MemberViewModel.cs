using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_Pracice1002.Models
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="姓名")]
        public string Name { get; set; }
        [Required(ErrorMessage ="請設定有效的日期格式")]
        [Display(Name = "生日")]
        public DateTime Birthday { get; set; }
    }
}