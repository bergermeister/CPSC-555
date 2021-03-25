namespace BankRPSQL.Models.ViewModels
{
   using DomainModels;

   public class TransactionHistoryVM : TransactionHistory
   {
      public string TransactionTypeName { get; set; }
   }
}
