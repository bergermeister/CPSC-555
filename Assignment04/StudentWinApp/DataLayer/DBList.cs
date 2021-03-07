namespace StudentWinApp.DataLayer
{
   using System;
   using System.Collections.Generic;
   using System.Data;

   class DBList
   {
      public static List< T > GetList< T >( DataTable dt ) where T : IEntity, new( )
      {
         List< T > TList = new List< T >( );
         foreach( DataRow dr in dt.Rows )
         {
            T t1 = new T( );
            t1.PopulateFields( dr );
            TList.Add( t1 );
         }
         return( TList );
      }

      public static List< T > GetListValueType< T >( DataTable dt, string colName ) where T : IConvertible
      {
         List< T > TList = new List< T >( );
         foreach( DataRow dr in dt.Rows )
         {
            TList.Add( ( T )dr[ colName ] );
         }
         return( TList );
      }
   }
}
