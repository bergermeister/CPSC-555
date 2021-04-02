namespace BankRPEF.Cache
{
   public interface IWebCache
   {
      // A cache provider needs to implement this interface21
      // via an adapter 
      void Remove( string key );
      void Store( string key, object obj );
      T Retrieve<T>( string key );
   }
}
