namespace BankRPEF.DataLayer
{
   public interface IRepositoryAuthentication
   {
      Models.UserInfo GetUserInfo( string username );
   }
}
