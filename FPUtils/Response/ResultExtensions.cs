using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace FPUtils.Response
{
   public static class ResultExtensions {
      public static Result<IEnumerable<T>> MergeResults<T>(this IEnumerable<Result<T>> results) {
         return new Result<IEnumerable<T>>(results.Select(x => x.Data), results.SelectMany(x => x.Messages));
      }

      public static bool HasStatusCodeError(this Result result, HttpStatusCode statusCode) {
         return result.Messages.Any(x => x.Code == statusCode.ToString());
      }
   }
}
