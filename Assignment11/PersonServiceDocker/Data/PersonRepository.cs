using PersonServiceDocker.Models;
using System.Collections.Generic;
using System.Linq;

namespace PersonServiceDocker.Data
{
   public class PersonRepository
   {
      private static Dictionary<int, Person> PersonsDict
 = new Dictionary<int, Person>();
      static PersonRepository( )
      {
         PersonsDict.Add( 1, new Person
         {
            Id = 1,
            FirstName = "Bill",
            LastName = "Baker",
            Email = "bill@xyz.com"
         } );
         PersonsDict.Add( 2, new Person
         {
            Id = 2,
            FirstName = "Sally",
            LastName = "Simpson",
            Email = "sally@xyz.com"
         } );
      }
      public static Person GetById( int id )
      {
         return PersonsDict[ id ];
      }
      public static List<Person> GetAll( )
      {
         return PersonsDict.Values.ToList( );
      }
      public static int GetCount( )
      {
         return PersonsDict.Count( );
      }
      public static void Remove( )
      {
         if( PersonsDict.Keys.Any( ) )
         {
            PersonsDict.Remove( PersonsDict.Keys.Last( ) );
         }
      }
      public static string Save( Person person )
      {
         var result = "";
         if( PersonsDict.ContainsKey( person.Id ) )
         {
            result = "Updated Person with id=" + person.Id;
         }
         else
         {
            result = "Added Person with id=" + person.Id;
         }
         PersonsDict.Add( person.Id, person );
         return result;
      }
   }
}
