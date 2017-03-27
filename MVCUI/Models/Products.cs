using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCUI.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public virtual Categories Category { get; set; }
        public string ProductName { get; set; }
        public int UnitInStock { get; set; }
        public double Price { get; set; }
        public double PriceVat { get; set; }
    }
}