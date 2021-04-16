using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RazorIdentity.Models
{
    public partial class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public bool OnSale { get; set; }
        public bool Discontinued { get; set; }
        public int CategoryId { get; set; }
        public int ProductColorId { get; set; }

        public virtual Categories Category { get; set; }
        public virtual ProductColors ProductColor { get; set; }
    }
}
