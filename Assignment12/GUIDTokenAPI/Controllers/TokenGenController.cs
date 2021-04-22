using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUIDTokenAPI.Controllers
{
   [Route( "api/[controller]" )]
   [ApiController]
   public class TokenGenController : ControllerBase
   {

      [HttpGet( "tok" )]
      public dynamic GenerateToken( ) // returns anonymous object with 
      { // three fields
         return new
         {
            Guid = Guid.NewGuid( ).ToString( ),
            Expires = DateTime.UtcNow.AddHours( 1 ),
            Org = "University of Bridgeport",
            Issuer = Environment.MachineName
         };
      }
   }
}
