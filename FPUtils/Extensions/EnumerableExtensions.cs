using System.Collections.Generic;
using System.Linq;

namespace FPUtils.Extensions {
   /// <summary>
   /// Extensions for IEnumerable type
   /// </summary>
   public static class EnumerableExtensions
   {
      /// <summary>
      /// Return TRUE if the collection object is not null and has any record
      /// </summary>
      /// <param name="collection"></param>
      /// <returns></returns>
      public static bool HasData<T>(this IEnumerable<T> collection)
      {
         return collection.IsNotNull() && collection.Any();
      }
   }
}
