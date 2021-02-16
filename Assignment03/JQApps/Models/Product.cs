using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JQApps.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
    }
}