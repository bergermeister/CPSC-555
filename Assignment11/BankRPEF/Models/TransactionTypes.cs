using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BankRPEF.Models
{
    public partial class TransactionTypes
    {
        public int TransactionTypeId { get; set; }
        public string TransactionTypeName { get; set; }
    }
}
