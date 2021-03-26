namespace BankRPSQL.Models.DomainModels
{
   using BankRPSQL.DataLayer;

   public class BillType : EntityBase
   {
      public int Id { get; set; }
      public string Name { get; set; }
   }
}
