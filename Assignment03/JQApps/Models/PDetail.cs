using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JQApps.Models
{
    public class PDetail
    {
        public int UnitsInStock { get; set; }
        public string QuantityPerUnit { get; set; }
        public bool Discontinued { get; set; }
    }
}