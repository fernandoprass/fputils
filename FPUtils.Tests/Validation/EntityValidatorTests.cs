using FluentAssertions;
using FPUtils.Response;
using FPUtils.Validation;
using Xunit;

namespace FPUtils.Tests.Validation
{
   /// <summary> Test Entity Validator </summary>
   public class EntityValidatorTests
   {
      /// <summary> Verify Contains  validator </summary>
      [Theory]
      [InlineData("", new[] { "A", "B" }, 1)]
      [InlineData(null, new[] { "A", "B" }, 1)]
      [InlineData("AB", new[] { "A", "B" }, 1)]
      [InlineData("C", new[] { "A", "B" }, 1)]
      [InlineData("A", new[] { "A", "B" }, 0)]
      [InlineData("B", new[] { "A", "B", "AB" }, 0)]
      [InlineData("AB", new[] { "A", "B", "AB" }, 0)]
      public void Contains(string value, string[] collection, int expectedNumberOfErrors)
      {
         ErrorMessage errorMessage = GenerateErrorMessage();

         var validator = new EntityValidator().Contains(value, collection, errorMessage);

         var result = validator.Validate();

         result.Messages.Should().HaveCount(expectedNumberOfErrors);
      }

      /// <summary> Verify ExactNumberOfCharacteres and ExactNumberOfCharacteresIf validators </summary>
      [Theory]
      [InlineData("", 1, 1 == 1, 0)]
      [InlineData(null, 1, 1 == 1, 0)]
      [InlineData("hello", 4, 1 == 1, 2)]
      [InlineData("hello", 4, 1 == 2, 1)]
      [InlineData("hello", 5, 1 == 1, 0)]
      [InlineData("hello world", 10, 1 == 1, 2)]
      [InlineData("hello world", 10, 1 == 2, 1)]
      [InlineData("hello world", 11, 1 == 1, 0)]
      public void ExactNumberOfCharacteres_and_ExactNumberOfCharacteresIf(string value, int lenght, bool expression, int expectedNumberOfErrors)
      {
         ErrorMessage errorMessage = GenerateErrorMessage();

         var validator = new EntityValidator()
            .ExactNumberOfCharacteres(value, lenght, errorMessage)
            .ExactNumberOfCharacteresIf(value, lenght, expression, errorMessage);

         var result = validator.Validate();

         result.Messages.Should().HaveCount(expectedNumberOfErrors);
      }

      /// <summary> Verify IsMandatory and IsMandatoryIf validators </summary>
      [Theory]
      [InlineData("", 1 == 1, 2)]
      [InlineData("", 1 == 2, 1)]
      [InlineData(null, 1 == 1, 2)]
      [InlineData(null, 1 == 2, 1)]
      [InlineData("hello", 1 == 1, 0)]
      [InlineData("hello", 1 == 2, 0)]
      public void IsMandatory_and_IsMandatoryIf(string value, bool expression, int expectedNumberOfErrors)
      {
         ErrorMessage errorMessage = GenerateErrorMessage();

         var validator = new EntityValidator()
            .IsMandatory(value, errorMessage)
            .IsMandatoryIf(value, expression, errorMessage);

         var result = validator.Validate();

         result.Messages.Should().HaveCount(expectedNumberOfErrors);
      }

      /// <summary> Verify IsValidEmailAddress  validator </summary>
      [Theory]
      [InlineData("", 0)]
      [InlineData(null, 0)]
      [InlineData("hello", 1)]
      [InlineData("@world.com", 1)]
      [InlineData("hello@world", 1)]
      [InlineData("hello@world.c", 1)]
      [InlineData("hello@world.com", 0)]
      public void IsValidEmailAddress(string value, int expectedNumberOfErrors)
      {
         ErrorMessage errorMessage = GenerateErrorMessage();

         var validator = new EntityValidator()
            .IsValidEmailAddress(value, errorMessage);

         var result = validator.Validate();

         result.Messages.Should().HaveCount(expectedNumberOfErrors);
      }

      /// <summary> Verify MaxLenght and MaxLenghtIf validators </summary>
      [Theory]
      [InlineData("", 1, 1 == 1, 0)]
      [InlineData(null, 1, 1 == 1, 0)]
      [InlineData("hello", 4, 1 == 1, 2)]
      [InlineData("hello", 4, 1 == 2, 1)]
      [InlineData("hey", 5, 1 == 1, 0)]
      [InlineData("hello", 5, 1 == 1, 0)]
      public void MaxLenght_and_MaxLenghtIf(string value, int lenght, bool expression, int expectedNumberOfErrors)
      {
         ErrorMessage errorMessage = GenerateErrorMessage();

         var validator = new EntityValidator()
            .MaxLenght(value, lenght, errorMessage)
            .MaxLenghtIf(value, lenght, expression, errorMessage);

         var result = validator.Validate();

         result.Messages.Should().HaveCount(expectedNumberOfErrors);
      }

      private static ErrorMessage GenerateErrorMessage()
      {
         return new ErrorMessage { Code = "001", Text = "message" };
      }
   }
}
