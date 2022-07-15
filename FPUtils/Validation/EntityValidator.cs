using FPUtils.Extensions;
using FPUtils.Response;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FPUtils.Validation
{
   public class EntityValidator : Validator<EntityValidator>
   {
      /// <summary>
      /// Determines whether a sequence contains a specified elemen
      /// </summary>
      /// <param name="value">The value to locate in the sequence</param>
      /// <param name="values">The sequence</param>
      /// <param name="message">The sequence in case of error</param>
      /// <returns></returns>
      public EntityValidator Contains(object value, string[] values, Message message)
      {
         return If(!values.Contains(value), message);
      }

      /// <summary>
      /// Determines whether a sequence contains only numeric characters
      /// </summary>
      /// <param name="value">The value to locate in the sequence</param>
      /// <param name="message">The sequence in case of error</param>
      /// <returns></returns>
      public EntityValidator ContainsOnlyNumber(string value, Message message)
      {
         if (!string.IsNullOrEmpty(value))
         {
            return If(value.Any(c => !char.IsNumber(c)), message);
         }
         return this;
      }

      /// <summary>
      /// Determines whether a string has an exact character length
      /// </summary>
      /// <param name="value">The string to be validated</param>
      /// <param name="lenght">Expected size</param>
      /// <param name="message">The sequence in case of error</param>
      /// <returns></returns>
      public EntityValidator ExactNumberOfCharacteres(string value, int lenght, Message message)
      {
         return If(!string.IsNullOrEmpty(value) && value.Length != lenght, message);
      }

      /// <summary>
      ///  Determines whether a string has an exact character length if a given condition is true
      /// </summary>
      /// <param name="value">The string to be validated</param>
      /// <param name="lenght">Expected size</param>
      /// <param name="expression">The condition necessary to apply the rule</param>
      /// <param name="message">The sequence in case of error</param>
      /// <returns></returns>
      public EntityValidator ExactNumberOfCharacteresIf(string value, int lenght, bool expression, Message message)
      {
         return expression ? MaxLenght(value, lenght, message) : this;
      }

      /// <summary>
      ///  Determines whether a value was filled
      /// </summary>
      /// <param name="value">The value</param>
      /// <param name="message">The sequence in case of error</param>
      /// <returns></returns>
      public EntityValidator IsMandatory(object value, Message message)
      {
         return value is string
                ? If(string.IsNullOrEmpty(value.ToString()), message)
                : If(value.IsNull(), message);
      }

      /// <summary>
      /// Determines whether was filled if a given condition is true
      /// </summary>
      /// <param name="value">The value</param>
      /// <param name="expression">The condition necessary to apply the rule</param>
      /// <param name="message">The sequence in case of error</param>
      /// <returns></returns>
      public EntityValidator IsMandatoryIf(string value, bool expression, Message message)
      {
         return expression ? IsMandatory(value, message) : this;
      }

      /// <summary>
      /// Determines whether a string is a valid date
      /// </summary>
      /// <param name="date">The value</param>
      /// <param name="message">The sequence in case of error</param>
      /// <returns></returns>
      public EntityValidator IsValidDate(string date, Message message)
      {
         if (!string.IsNullOrEmpty(date))
         {
            DateTime.TryParse(date, out var dateTime);
            return If(dateTime.IsNull(), message);
         }
         return this;
      }

      /// <summary>
      /// Determines whether a string is a valid email address
      /// </summary>
      /// <param name="value">The value</param>
      /// <param name="message">The sequence in case of error</param>
      /// <returns></returns>
      public EntityValidator IsValidEmailAddress(string email, Message message)
      {
         if (!string.IsNullOrEmpty(email))
         {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(email);
            return If(!match.Success, message);
         }
         return this;
      }

      /// <summary>
      /// Determines whether a string has the maximum size allowed
      /// </summary>
      /// <param name="value">The string to be validated</param>
      /// <param name="maxLenght">Expected size</param>
      /// <param name="message">The sequence in case of error</param>
      /// <returns></returns>
      public EntityValidator MaxLenght(string value, int maxLenght, Message message)
      {
         return If(!string.IsNullOrEmpty(value) && value.Length > maxLenght, message);
      }

      /// <summary>
      /// Determines whether a string has the maximum size allowed if a given condition is true
      /// </summary>
      /// <param name="value">The string to be validated</param>
      /// <param name="maxLenght">Expected size</param>
      /// <param name="expression">The condition necessary to apply the rule</param>
      /// <param name="message">The sequence in case of error</param>
      /// <returns></returns>
      public EntityValidator MaxLenghtIf(string value, int maxLenght, bool expression, Message message)
      {
         return expression ? MaxLenght(value, maxLenght, message) : this;
      }
   }
}
