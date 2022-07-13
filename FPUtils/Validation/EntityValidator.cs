using FPUtils.Extensions;
using FPUtils.Response;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FPUtils.Validation
{
   public class EntityValidator : Validator<EntityValidator>
   {
      public EntityValidator Contains(object value, string[] values, Message message)
      {
         return If(!values.Contains(value), message);
      }

      public EntityValidator ContainsOnlyNumber(string value, Message message)
      {
         if (!string.IsNullOrEmpty(value))
         {
            return If(value.Any(c => !char.IsNumber(c)), message);
         }
         return this;
      }

      public EntityValidator ExactNumberOfCharacteres(string value, int lenght, Message message)
      {
         return If(!string.IsNullOrEmpty(value) && value.Length != lenght, message);
      }

      public EntityValidator ExactNumberOfCharacteresIf(string value, int lenght, bool expression, Message message)
      {
         return expression ? MaxLenght(value, lenght, message) : this;
      }

      public EntityValidator IsMandatory(string value, Message message)
      {
         return If(string.IsNullOrEmpty(value), message);
      }

      public EntityValidator IsMandatory(object value, Message message)
      {
         return If(value.IsNull(), message);
      }

      public EntityValidator IsMandatoryIf(string value, bool expression, Message message)
      {
         return expression ? IsMandatory(value, message) : this;
      }

      public EntityValidator IsValidDate(string date, Message message)
      {
         if (!string.IsNullOrEmpty(date))
         {
            DateTime.TryParse(date, out var dateTime);
            return If(dateTime.IsNull(), message);
         }
         return this;
      }

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

      public EntityValidator MaxLenght(string value, int maxLenght, Message message)
      {
         return If(!string.IsNullOrEmpty(value) && value.Length > maxLenght, message);
      }

      public EntityValidator MaxLenghtIf(string value, int maxLenght, bool expression, Message message)
      {
         return expression ? MaxLenght(value, maxLenght, message) : this;
      }
   }
}
