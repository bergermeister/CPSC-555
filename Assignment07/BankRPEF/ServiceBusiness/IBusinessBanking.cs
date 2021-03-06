﻿namespace BankRPEF.ServiceBusiness
{
   using BankRPEF.Models;
   using BankRPEF.Models.ViewModels;
   using System.Collections.Generic;

   public interface IBusinessBanking
   {
      decimal GetCheckingBalance( long checkingAccountNum );
      decimal GetSavingBalance( long savingAccountNum );
      long GetCheckingAccountNumForUser( string username );
      long GetSavingAccountNumForUser( string username );
      bool TransferCheckingToSaving( long checkingAccountNum, long savingAccountNum, decimal amount );
      bool TransferSavingToChecking( long checkingAccountNum, long savingAccountNum, decimal amount );
      List< TransactionHistoryVM > GetTransactionHistory( long checkingAccountNum, long savingAccountNum );
      List< BillTypes > GetBillTypes( );
      bool PayBillFromChecking( long checkingAccountNum, decimal amount, decimal transactionFee );
      bool PayBillFromSaving( long savingAccountNum, decimal amount, decimal transactionFee );
   }
}
