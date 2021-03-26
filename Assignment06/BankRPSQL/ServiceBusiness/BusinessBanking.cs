namespace BankRPSQL.ServiceBusiness
{
   using BankRPSQL.DataLayer;
   using BankRPSQL.Models.DomainModels;
   using BankRPSQL.Models.ViewModels;
   using System;
   using System.Collections.Generic;

   public class BusinessBanking : IBusinessBanking
   {
      IRepositoryBanking _irepbank = null;

      public BusinessBanking( IRepositoryBanking ibank )
      {
         _irepbank = ibank;
      }

      public BusinessBanking( ) : this( new Repository( ) )
      {
      }

      public decimal GetCheckingBalance( long checkingAccountNum )
      {
         return _irepbank.GetCheckingBalance( checkingAccountNum );
      }

      public decimal GetSavingBalance( long savingAccountNum )
      {
         return _irepbank.GetSavingBalance( savingAccountNum );
      }

      public long GetCheckingAccountNumForUser( string username )
      {
         return _irepbank.GetCheckingAccountNumForUser( username );
      }

      public long GetSavingAccountNumForUser( string username )
      {
         return _irepbank.GetSavingAccountNumForUser( username );
      }

      public bool TransferCheckingToSaving( long checkingAccountNum, long savingAccountNum, decimal amount )
      {
         return _irepbank.TransferCheckingToSaving( checkingAccountNum, savingAccountNum, amount, 0 );
      }

      public bool TransferSavingToChecking( long checkingAccountNum, long savingAccountNum, decimal amount )
      {
         return _irepbank.TransferSavingToChecking( checkingAccountNum, savingAccountNum, amount, 0 );
      }

      public List< TransactionHistoryVM > GetTransactionHistory( long checkingAccountNum, long savingAccountNum )
      {
         return _irepbank.GetTransactionHistory( checkingAccountNum, savingAccountNum );
      }

      public List< BillType > GetBillTypes( )
      {
         return _irepbank.GetBillTypes( );
      }

      public bool PayBillFromChecking( long checkingAccountNum, decimal amount, decimal transactionFee )
      {
         return _irepbank.PayBillFromChecking( checkingAccountNum, amount, transactionFee );
      }

      public bool PayBillFromSaving( long savingAccountNum, decimal amount, decimal transactionFee )
      {
         return _irepbank.PayBillFromSaving( savingAccountNum, amount, transactionFee );
      }
   }
}
