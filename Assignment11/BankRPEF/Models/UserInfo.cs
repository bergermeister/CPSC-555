namespace BankRPEF.Models
{
   public class UserInfo
   {
      public long CheckingAccountNumber { get; set; }
      public long SavingAccountNumber { get; set; }
      public string UserName { get; set; }
      public string Password { get; set; }
      public string Token { get; set; }
   }
}
