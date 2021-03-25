namespace BankRPSQL.DataLayer
{
   using System;
   using System.Collections.Generic;
   using System.Data;

   public class DBList
   {
      public static List< T > ToList< T >( DataTable dt ) where T : IEntity, new( )
      { 
         // will do conversion from dt to List<class>
         List< T > TList = new List< T >( );
         foreach( DataRow dr in dt.Rows )
         {
            T tp = new T( );
            tp.SetFields( dr );
            TList.Add( tp );
         }
         return( TList );
      }

      public static List<T> GetListValueType<T>( DataTable dt, string colname ) where T : IConvertible
      { 
         // will do conversion from dt to List<>for value types including string
         List< T > TList = new List< T >( );
         foreach( DataRow dr in dt.Rows )
         {
            TList.Add( ( T )dr[ colname ] );
         }
         return( TList );
      }
   }
}
