namespace StudentWinApp.DataLayer
{
   using System;
   using System.Collections.Generic;
   using System.Configuration;
   using System.Data;
   using System.Data.SqlClient;

   class DataAccess
   {
      public static string ConnectionString = ConfigurationManager.ConnectionStrings[ "STDB2017" ].ConnectionString;

      public static object GetSingleAnswer( string sql, List< SqlParameter > PList, SqlConnection connc = null, 
                                            SqlTransaction sqtr = null, bool IsStoredProc = false )
      {
         SqlConnection conn = null;
         if( sqtr == null )
         {
            conn = new SqlConnection( ConnectionString );
         }
         else
         {
            conn = connc;
         }
         object obj = null;
         try
         {
            if( sqtr == null )
            {
               conn.Open( );
            }
            SqlCommand cmd = new SqlCommand( sql, conn );
            if( sqtr != null )
            {
               cmd.Transaction = sqtr;
            }
            if( IsStoredProc == true )
            {
               cmd.CommandType = CommandType.StoredProcedure;
            }
            if( PList != null )
            {
               foreach( SqlParameter param in PList )
               {
                  cmd.Parameters.Add( param );
               }
            }
            obj = cmd.ExecuteScalar( );
         }
         catch( Exception ex )
         {
            Console.WriteLine( ex.Message );
            throw;   // Send the error back to caller
         }
         finally
         {
            if( sqtr == null )
            {
               conn.Close( );
            }
         }
         return( obj );
      }

      public static DataTable GetManyRowsCols( string sql, List< SqlParameter > PList, SqlConnection connc = null, 
                                               SqlTransaction sqtr = null, bool IsStoredProc = false )
      {
         SqlConnection conn = null;
         if( sqtr == null )
         {
            conn = new SqlConnection( ConnectionString );
         }
         else
         {
            conn = connc;
         }
         DataTable dt = new DataTable( );
         try
         {
            if( sqtr == null )
            {
               conn.Open( );
            }
            SqlCommand cmd = new SqlCommand( sql, conn );
            if( sqtr != null )
            {
               cmd.Transaction = sqtr;
            }
            if( IsStoredProc == true )
            {
               cmd.CommandType = CommandType.StoredProcedure;
            }
            if( PList != null )
            {
               foreach( SqlParameter param in PList )
               {
                  cmd.Parameters.Add( param );
               }
            }
            SqlDataAdapter da = new SqlDataAdapter( );
            da.SelectCommand = cmd;
            da.Fill( dt );
         }
         catch( Exception ex )
         {
            Console.WriteLine( ex.Message );
            throw;   // Send the error back to caller
         }
         finally
         {
            if( sqtr == null )
            {
               conn.Close( );
            }
         }
         return( dt );
      }

      public static int InsertUpdateDelete( string sql, List<SqlParameter> PList, SqlConnection connc = null,
                                                  SqlTransaction sqtr = null, bool IsStoredProc = false )
      {
         SqlConnection conn = null;
         if( sqtr == null )
         {
            conn = new SqlConnection( ConnectionString );
         }
         else
         {
            conn = connc;
         }
         int rowsModified = 0;
         try
         {
            if( sqtr == null )
            {
               conn.Open( );
            }
            SqlCommand cmd = new SqlCommand( sql, conn );
            if( sqtr != null )
            {
               cmd.Transaction = sqtr;
            }
            if( IsStoredProc == true )
            {
               cmd.CommandType = CommandType.StoredProcedure;
            }
            if( PList != null )
            {
               foreach( SqlParameter param in PList )
               {
                  cmd.Parameters.Add( param );
               }
            }
            rowsModified = cmd.ExecuteNonQuery( );
         }
         catch( Exception ex )
         {
            Console.WriteLine( ex.Message );
            throw;   // Send the error back to caller
         }
         finally
         {
            if( sqtr == null )
            {
               conn.Close( );
            }
         }
         return( rowsModified );
      }
   }
}
