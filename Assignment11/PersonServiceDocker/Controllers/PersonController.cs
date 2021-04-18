using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonServiceDocker.Data;
using PersonServiceDocker.Models;
using System.Collections.Generic;

namespace PersonServiceDocker.Controllers
{
   [Authorize]
   [Route( "api/[controller]" )]
   [ApiController]
   public class PersonController : ControllerBase
   {
      [HttpGet( "get/{id}" )]
      public Person GetPerson( int id )
      {
         return PersonRepository.GetById( id );
      }
      [HttpGet( "remove" )]
      public string RemovePerson( )
      {
         PersonRepository.Remove( );
         return "Last person remove. Total count: "
         + PersonRepository.GetCount( );
      }
      [HttpGet( "all" )]
      public List<Person> GetPersons( )
      {
         string nm = HttpContext.User.Identity.Name; // was stored as username in UserService
         if( nm == "admin" ) 
            return PersonRepository.GetAll( );
         else
         {
            HttpContext.Response.StatusCode = 401; // unauthorized
            return null;
         }

      }
      [HttpPost( "person/save" )]
      public string AddPerson( [FromBody] Person person )
      {
         return PersonRepository.Save( person );
      }
   }
}
