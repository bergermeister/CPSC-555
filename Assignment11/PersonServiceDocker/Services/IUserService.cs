using PersonServiceDocker.Models;
using System.Collections.Generic;

namespace PersonServiceDocker.Services
{
   public interface IUserService
   {
      User Authenticate( string username, string password );
      IEnumerable<User> GetAll( );
   }
}
