using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonServiceDocker.Models;
using PersonServiceDocker.Services;

namespace PersonServiceDocker.Controllers
{
   [Route( "api/[controller]" )]
   [ApiController]
   [Authorize]
   public class UsersController : ControllerBase
   {
      private IUserService _userService;
      public UsersController( IUserService userService )
      {
         _userService = userService;
      }
      [AllowAnonymous]
      [HttpPost( "authenticate" )]
      public IActionResult Authenticate( [FromBody] User user )
      {
         var userfound = _userService.Authenticate(user.Username, user.Password);
         if( userfound == null )
         {
            return BadRequest( new
            {
               message = "incorrect username or password"
            } );
         }
         return Ok( userfound );
      }
      [HttpGet( "allusers" )] // protected method
      public IActionResult GetAll( )
      {
         string nm = HttpContext.User.Identity.Name; // was stored as username in UserService
         if( nm == "admin" ) // only admin user can see other users
         {
            var users = _userService.GetAll();
            return Ok( users );
         }
         else
         {
            HttpContext.Response.StatusCode = 401; // unauthorized
            return Unauthorized( null );
         }
      }
   }
}
