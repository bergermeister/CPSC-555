using BankRPEF.DataLayer;
using BankRPEF.Models;

namespace BankRPEF.ServiceBusiness
{
   public class BusinessAuthentication : IBusinessAuthentication
   {
      IRepositoryAuthentication _irepauth = null;

      public BusinessAuthentication( IRepositoryAuthentication irepauth )
      {
         _irepauth = irepauth;
      }

      public BusinessAuthentication( MyBankContext context ) : this( new RepositoryEF( context ) )
      { }

      public UserInfo GetUserInfo( string username )
      {
         return _irepauth.GetUserInfo( username );
      }

   }
}
