using BankRPEF.Models;

namespace BankRPEF.Service
{
   public interface IUserService
   {
      UserInfo Authenticate( string username, string password );
   }
}
