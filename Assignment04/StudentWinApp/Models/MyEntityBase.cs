namespace StudentWinApp.Models
{
   using System;
   using System.Data;
   using System.Reflection;
   using StudentWinApp.DataLayer;

   class MyEntityBase : IEntity
   {
      public void PopulateFields( DataRow dr )
      {
         Type tp = this.GetType( );
         foreach( PropertyInfo pi in tp.GetProperties( ) )
         {
            pi.SetValue( this, dr[ pi.Name ] );
         }
      }
   }
}
