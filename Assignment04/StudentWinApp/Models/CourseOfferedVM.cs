namespace StudentWinApp.Models
{
   class CourseOfferedVM
   {
      public string CourseNum { get; set; }
      public string CourseName { get; set; }
      public int Credits { get; set; }
      public string Instructor { get; set; }
      public int Capacity { get; set; }
      public int Enrolled { get; set; }
   }
}
