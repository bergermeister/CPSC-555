namespace BankRPSQL.DataLayer
{
   using System;
   using System.Data;
   using System.Reflection;

   public class EntityBase : IEntity
   {
      public void SetFields( DataRow dr )
      {
         // use reflection to set the fields of a class object from DataRow
         Type tp = this.GetType( );
         foreach( PropertyInfo pi in tp.GetProperties( ) )
         {
            if( ( null != pi ) && ( pi.CanWrite ) && ( dr.Table.Columns.Contains( pi.Name ) ) )
            {
               pi.SetValue( this, dr[ pi.Name ], null );
            }
         }
      }
   }
}
