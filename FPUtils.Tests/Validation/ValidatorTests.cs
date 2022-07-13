using FluentAssertions;
using FPUtils.Response;
using FPUtils.Validation;
using System.Linq;
using Xunit;

namespace FPUtils.Tests.Validation
{
   /// <summary> Test Validator </summary>
   public class ValidatorTests
   {
      /// <summary> Verify If validators </summary>
      [Theory]
      [InlineData(1 == 1, 1)]
      [InlineData(1 == 2, 0)]
      public void If(bool expression, int expectedNumberOfErrors)
      {
         var errorMessage = new ErrorMessage { Code = "001", Text = "message" };

         var validator = new EntityValidator()
            .If(expression, errorMessage);

         var result = validator.Validate();

         result.Messages.Should().HaveCount(expectedNumberOfErrors);
         if (result.HasMessage)
         {
            result.Messages.First().Should().BeOfType<ErrorMessage>();
         }
      }
   }
}
