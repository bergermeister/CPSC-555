namespace BankRPSQL.Models.DomainModels
{
   using System;
   using DataLayer;

   public partial class TransactionHistory : EntityBase
   {
      public long TransactionId { get; set; }
      public DateTime TransactionDate { get; set; }
      public long CheckingAccountNumber { get; set; }
      public long SavingAccountNumber { get; set; }
      public decimal Amount { get; set; }
      public decimal TransactionFee { get; set; }
      public int TransactionTypeId { get; set; }
   }
}
