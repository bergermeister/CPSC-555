using BankRPEF.Models;
using BankRPEF.Models.ViewModels;
using BankRPEF.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankRPEF.Controllers
{
   [Authorize]
   [ApiController]
   [Route( "api/[controller]" )]
   public class BankingController : ControllerBase
   {
      private IBankingService _bankingService;

      public BankingController( IBankingService bankingService )
      {
         this._bankingService = bankingService;
      }

      [HttpGet( "GetCheckingBalance/{checkingAccountNum}" )]
      public IActionResult GetCheckingBalance( long checkingAccountNum )
      {
         var balance = _bankingService.GetCheckingBalance( checkingAccountNum );
         return ( Ok( balance ) );
      }
      [HttpGet( "GetSavingBalance/{savingAccountNum}" )]
      public IActionResult GetSavingBalance( long savingAccountNum )
      {
         var balance = _bankingService.GetSavingBalance( savingAccountNum );
         return ( Ok( balance ) );
      }
      [HttpGet( "GetCheckingAccountNumForUser/{username}" )]
      public IActionResult GetCheckingAccountNumForUser( string username )
      {
         var accountNum = _bankingService.GetCheckingAccountNumForUser( username );
         return ( Ok( accountNum ) );
      }
      [HttpGet("GetSavingAccountNumForUser/{username}")]
      public IActionResult GetSavingAccountNumForUser( string username )
      {
         var accountNum = _bankingService.GetSavingAccountNumForUser( username );
         return ( Ok( accountNum ) );
      }

      [HttpPut("TransferCheckingToSaving")]
      public IActionResult TransferCheckingToSaving( [FromBody] Transfer transfer )
      {
         return( Ok( _bankingService.TransferCheckingToSaving( transfer.CheckingAccountNum, 
                                                               transfer.SavingAccountNum, 
                                                               transfer.Amount, 
                                                               transfer.TransactionFee ) ) );
      }
      [HttpPut( "TransferSavingToChecking" )]
      public IActionResult TransferSavingToChecking( [FromBody] Transfer transfer )
      {
         return ( Ok( _bankingService.TransferSavingToChecking( transfer.CheckingAccountNum,
                                                                transfer.SavingAccountNum,
                                                                transfer.Amount,
                                                                transfer.TransactionFee ) ) );
      }
      [HttpGet( "GetTransactionHistory" )]
      public List<TransactionHistoryVM> GetTransactionHistory( [FromBody] Transfer transfer )
      {
         return ( _bankingService.GetTransactionHistory( transfer.CheckingAccountNum, transfer.SavingAccountNum ) );
      }
      [HttpGet("BillTypes")]
      public List<BillTypes> GetBillTypes( )
      {
         return ( _bankingService.GetBillTypes( ) );
      }
      
      [HttpPut( "PayBillFromChecking" )]
      public IActionResult PayBillFromChecking( [FromBody] Transfer transfer )
      {
         return ( Ok( _bankingService.PayBillFromChecking( transfer.CheckingAccountNum,
                                                           transfer.Amount,
                                                           transfer.TransactionFee ) ) );
      }
      [HttpPut( "PayBillFromSaving" )]
      public IActionResult PayBillFromSaving( [FromBody] Transfer transfer )
      {
         return ( Ok( _bankingService.PayBillFromSaving( transfer.SavingAccountNum,
                                                         transfer.Amount,
                                                         transfer.TransactionFee ) ) );
      }
   }
}
