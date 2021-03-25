namespace BankRPSQL.DataLayer
{
   public interface IRepositoryAuthentication
   {
      Models.UserInfo GetUserInfo( string username );
   }
}
