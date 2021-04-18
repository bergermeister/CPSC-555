using BankRPEF.Models;
using BankRPEF.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankRPEF.Controllers
{
   [Route( "api/[controller]" )]
   [ApiController]
   public class UserController : ControllerBase
   {
      private IUserService _userService;

      public UserController( IUserService userService )
      {
         _userService = userService;
      }

      [AllowAnonymous]
      [HttpPost( "authenticate" )]
      public IActionResult Authenticate( [FromBody] UserInfo user )
      {
         var userfound = _userService.Authenticate(user.UserName, user.Password);
         if( userfound == null )
         {
            return BadRequest( new
            {
               message = "incorrect username or password"
            } );
         }
         return Ok( userfound );
      }
   }
}
