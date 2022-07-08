using System;

namespace FPUtils.Extensions {
   /// <summary>
   /// Extensions for Guid type
   /// </summary>
   public static class GuidExtension
   {
      /// <summary> Return TRUE if the guid is empty</summary>
      /// <param name="value"></param>
      /// <returns></returns>
      public static bool IsEmpty(this Guid guid)
      {
         return guid == Guid.Empty;
      }

      /// <summary> Return TRUE if the guid is not empty</summary>
      /// <param name="value"></param>
      /// <returns></returns>
      public static bool IsNotEmpty(this Guid guid) {
         return guid != Guid.Empty;
      }

      /// <summary> Return TRUE if a nullable guid is empty</summary>
      /// <param name="value"></param>
      /// <returns></returns>
      public static bool IsEmpty(this Guid? guid) {
         return guid.IsNull() || IsEmpty(guid.Value);
      }

      /// <summary> Return TRUE if a nullable guid is empty</summary>
      /// <param name="value"></param>
      /// <returns></returns>
      public static bool IsNotEmpty(this Guid? guid) {
         return guid.IsNotNull() && IsNotEmpty(guid.Value);
      }
   }
}
