namespace StudentWinApp.DataLayer
{
   using System.Data;

   interface IEntity
   {
      void PopulateFields( DataRow dr );
   }
}
