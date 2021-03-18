using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StateManagement.Models
{
   public class UserInfo
   {
      [Required( ErrorMessage = "{0} is required.." )]
      public string FirstName { get; set; }
      [Required( ErrorMessage = "{0} is required.." )]
      public string LastName { get; set; }
      [Required( ErrorMessage = "{0} is required.." )]
      [DataType( DataType.EmailAddress )]
      public string Email { get; set; }
      [Required( ErrorMessage = "address is required.." )]
      public string StreetAddress { get; set; }
      [Required( ErrorMessage = "city is required.." )]
      public string City { get; set; }
      [Required( ErrorMessage = "state is required.." )]
      public string State { get; set; }
      [Required( ErrorMessage = "telephone is required.." )]
      [DataType( DataType.PhoneNumber )]
      public string Telephone { get; set; }
      public string CellPhone { get; set; }
      [Required( ErrorMessage = "{0} is required.." )]
      [Range( 1000, 10000, ErrorMessage = "has to be between 1000 and 10000" )]
      public int UserPin { get; set; }
      public string Wizhidden { get; set; }

   }
}
