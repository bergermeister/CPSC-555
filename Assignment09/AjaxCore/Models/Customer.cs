using System;
using System.ComponentModel.DataAnnotations;

namespace AjaxCore.Models
{
   public class Customer
   {
      [Display( Name = "First Name" )]
      [Required( ErrorMessage = "First name is required.." )]
      public string FirstName { get; set; }
      [Required( ErrorMessage = "Last Name is required.." )]
      [Display( Name = "Last Name" )]
      public string LastName { get; set; }
      [EmailAddress( ErrorMessage = "invalid email.." )]
      public string Email { get; set; }
      [Display( Name = "Date of Birth" ), DataType( DataType.Date )]
      public DateTime DateOfBirth { get; set; }
   }
}
