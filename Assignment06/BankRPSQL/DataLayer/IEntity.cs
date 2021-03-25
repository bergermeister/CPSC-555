namespace BankRPSQL.DataLayer
{
   using System.Data;

   public interface IEntity
   {
      void SetFields( DataRow dr );
   }
}
