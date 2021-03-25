namespace BankRPSQL.DataLayer
{
   using System.Collections.Generic;
   using Models.ViewModels;

   public interface IRepositoryBanking
   {
      decimal GetCheckingBalance( long checkingAccountNum );
      decimal GetSavingBalance( long savingAccountNum );
      long GetCheckingAccountNumForUser( string username );
      long GetSavingAccountNumForUser( string username );
      bool TransferCheckingToSaving( long checkingAccountNum, long savingAccountNum, decimal amount, decimal transactionFee );
      bool TransferSavingToChecking( long checkingAccountNum, long savingAccountNum, decimal amount, decimal transactionFee );
      List< TransactionHistoryVM > GetTransactionHistory( long checkingAccountNum );
   }
}
