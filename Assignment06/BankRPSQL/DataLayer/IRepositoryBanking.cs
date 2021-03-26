namespace BankRPSQL.DataLayer
{
   using System.Collections.Generic;
   using BankRPSQL.Models.DomainModels;
   using Models.ViewModels;

   public interface IRepositoryBanking
   {
      decimal GetCheckingBalance( long checkingAccountNum );
      decimal GetSavingBalance( long savingAccountNum );
      long GetCheckingAccountNumForUser( string username );
      long GetSavingAccountNumForUser( string username );
      bool TransferCheckingToSaving( long checkingAccountNum, long savingAccountNum, decimal amount, decimal transactionFee );
      bool TransferSavingToChecking( long checkingAccountNum, long savingAccountNum, decimal amount, decimal transactionFee );
      List< TransactionHistoryVM > GetTransactionHistory( long checkingAccountNum, long savingAccountNum );
      List< BillType > GetBillTypes( );
      bool PayBillFromChecking( long checkingAccountNum, decimal amount, decimal transactionFee );
      bool PayBillFromSaving( long savingAccountNum, decimal amount, decimal transactionFee );
   }
}
