namespace CoreConcepts.Pages.Models
{
   using System.Collections.Generic;

   public class CustomerInfo
   {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Email { get; set; }
      public List< StockInfo > STList { get; set; }
   }
}
