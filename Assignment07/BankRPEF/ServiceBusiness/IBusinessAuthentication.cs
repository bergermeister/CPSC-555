namespace BankRPEF.ServiceBusiness
{
   public interface IBusinessAuthentication
   {
      Models.UserInfo GetUserInfo( string username );
   }
}
