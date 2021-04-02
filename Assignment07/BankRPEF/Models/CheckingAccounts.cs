using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BankRPEF.Models
{
    public partial class CheckingAccounts
    {
        public string Username { get; set; }
        public long CheckingAccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
