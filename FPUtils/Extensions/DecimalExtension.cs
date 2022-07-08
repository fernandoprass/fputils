namespace FPUtils.Extensions {
   /// <summary>
   /// Extensions for Decimal type
   /// </summary>
   public static class DecimalExtension
   {
      /// <summary> Return TRUE if the value is equal zero </summary>
      /// <param name="value"></param>
      /// <returns></returns>
      public static bool EqualZero(this decimal value)
      {
         return value == 0;
      }

      /// <summary> Return TRUE if the value is equal zero </summary>
      /// <param name="value"></param>
      /// <returns></returns>
      public static bool EqualZero(this decimal? value)
      {
         return value.HasValue && EqualZero(value.Value);
      }

      /// <summary> Return TRUE if the value is greater zero </summary>
      /// <param name="value"></param>
      /// <returns></returns>
      public static bool GreaterThanZero(this decimal value)
      {
         return value > 0;
      }

      /// <summary> Return TRUE if the value is greater than zero </summary>
      /// <param name="value"></param>
      /// <returns></returns>
      public static bool GreaterThanZero(this decimal? value)
      {
         return value.HasValue && GreaterThanZero(value.Value);
      }

      /// <summary> Return TRUE if the value is greater than or equal zero </summary>
      /// <param name="value"></param>
      /// <returns></returns>
      public static bool GreaterThanOrEqualZero(this decimal value)
      {
         return value >= 0;
      }

      /// <summary> Return TRUE if the value is greater than or equal zero </summary>
      /// <param name="value"></param>
      /// <returns></returns>
      public static bool GreaterThanOrEqualZero(this decimal? value)
      {
         return value.HasValue && GreaterThanOrEqualZero(value.Value);
      }

      /// <summary> Return TRUE if the value is less than zero </summary>
      /// <param name="value"></param>
      /// <returns></returns>
      public static bool LessThanZero(this decimal value)
      {
         return value < 0;
      }

      /// <summary> Return TRUE if the value is less than zero </summary>
      /// <param name="value"></param>
      /// <returns></returns>
      public static bool LessThanZero(this decimal? value)
      {
         return value.HasValue && LessThanZero(value.Value);
      }

      /// <summary> Return TRUE if the value is less than or equal zero </summary>
      /// <param name="value"></param>
      /// <returns></returns>
      public static bool LessThanOrEqualZero(this decimal value)
      {
         return value <= 0;
      }

      /// <summary> Return TRUE if the value is less than or equal zero </summary>
      /// <param name="value"></param>
      /// <returns></returns>
      public static bool LessThanOrEqualZero(this decimal? value)
      {
         return value.HasValue && LessThanOrEqualZero(value.Value);
      }

   }
}
