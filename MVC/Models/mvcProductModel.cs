using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class mvcProductModel
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Name { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Stock { get; set; }
        public Nullable<int> Code { get; set; }

    }
}