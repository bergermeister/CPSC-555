using BankRPEF.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BankRPEF.Service
{
   public class UserService : IUserService
   {
      private readonly AppSettings _appSettings;
      private MYBANKContext _dbContext = null;

      public UserService( IOptions<AppSettings> appSettings,
                          DbContext dbContext )
      {
         _appSettings = appSettings.Value;
         _dbContext = dbContext as MYBANKContext;
      }
      public UserInfo Authenticate( string username, string password )
      {
         var user = _dbContext.AspNetUsers.SingleOrDefault(x => x.UserName == username && x.PasswordHash == password);
         //// return null if user not found
         if( user == null )
            return null;
         // authentication successful so generate jwt token
         var tokenHandler = new JwtSecurityTokenHandler();
         var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
         var tokenDescriptor = new SecurityTokenDescriptor
         {
            Subject = new ClaimsIdentity(new Claim[]
            {
               new Claim(ClaimTypes.Name, user.UserName.ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(2), // for subscribers of API, it could be longer duration
            // Sha256 with HMAC, secret as the key for Sha256
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
         };
         var token = tokenHandler.CreateToken(tokenDescriptor);
         string tokenStr = tokenHandler.WriteToken( token );
         // remove password before returning
         UserInfo uinfo = new UserInfo
         {
            UserName = user.UserName,
            Token = tokenStr
         };
         return uinfo;
      }
   }
}
