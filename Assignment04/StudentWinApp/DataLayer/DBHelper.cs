﻿namespace StudentWinApp.DataLayer
{
   using System.Collections.Generic;
   using System.Data;
   using System.Data.SqlClient;

   class DBHelper
   {
      public static void AddSqlParam( List< SqlParameter > PList, string paramName,
                                      SqlDbType paramType, object paramValue, int size = 0 )
      {
         SqlParameter p = null;
         if( size == 0 )
         {
            p = new SqlParameter( paramName, paramType );
         }
         else
         {
            p = new SqlParameter( paramName, paramType, size );
         }
         p.Value = paramValue;
         PList.Add( p );
      }
   }
}
