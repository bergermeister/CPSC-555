namespace StudentWinApp.Models
{
   class CourseEnrolledVM : MyEntityBase
   {
      public string SemesterId { get; set; }
      public string CourseNum { get; set; }
      public string CourseName { get; set; }
      public string CourseGrade { get; set; }
      public string Credits { get; set; }
   }
}
