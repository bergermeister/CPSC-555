namespace StudentWinApp.Models
{
   class CourseEnrollmentVM : MyEntityBase
   {
      public long StudentId { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Major { get; set; }
      public string Email { get; set; }
      public int Credits { get; set; }
   }
}
