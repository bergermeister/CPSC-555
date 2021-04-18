namespace BankRPEF.Models
{
   public class Transfer
   {
      public long CheckingAccountNum { get; set; }
      public long SavingAccountNum { get; set; }
      public decimal Amount { get; set; }
      public decimal TransactionFee { get; set; }
   }
}
