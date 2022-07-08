using FluentAssertions;
using FPUtils.Response;
using System.Linq;
using Xunit;

namespace FPUtils.Tests.Response
{
   /// <summary>
   /// Tests for Result class
   /// </summary>
   public class ResultTests
   {
      /// <summary>Validate Result with errors and warnings</summary>
      [Fact]
      public void Result_ValidadeErrorsAndWarnings_ShouldRetunIsInvalid()
      {
         var errorMessage = new ErrorMessage("code1","text1" );
         var warningMessage = new WarningMessage("code2", "text2");

         var result = new Result();
         result.AddMessage(errorMessage);
         result.AddMessage(warningMessage);

         result.Message.Should().BeNull();
         result.HasError.Should().Be(true);
         result.HasWarning.Should().Be(true);
         result.Messages.Should().HaveCount(2);
         result.Messages.First().Should().Be(errorMessage);
         result.Messages.First().Code.Should().Be("code1");
         result.Messages.Last().Text.Should().Be("text2");

         result.IsValid.Should().Be(false);
      }

      /// <summary>Validate Result with warnings and without errors</summary>
      [Fact]
      public void Result_ValidadeWarnings_ShouldRetunIsValid()
      {
         var warningMessage = new WarningMessage("code1", "text1");

         var result = new Result(warningMessage);

         result.Message.Should().BeNull();
         result.HasError.Should().Be(false);
         result.HasWarning.Should().Be(true);
         result.Messages.Should().HaveCount(1);
         result.Messages.First().Should().Be(warningMessage);
         result.Messages.First().Code.Should().Be("code1");
         result.IsValid.Should().Be(true);
      }

      /// <summary>Validate Result with messages wtih variables</summary>
      [Fact]
      public void Result_ValidadeMessageWithVariables_ShouldRetunMessagesAndVariables()
      {
         var infoMessage = new InformationMessage("code1", "text1");
         infoMessage.AddVariable("var1", "value1");
         infoMessage.AddVariable("var2", "value2");

         var result = new Result(infoMessage);

         result.Message.Should().BeNull();
         result.HasError.Should().Be(false);
         result.HasWarning.Should().Be(false);
         result.Messages.Should().HaveCount(1);
         result.Messages.First().Should().Be(infoMessage);
         result.Messages.First().Code.Should().Be("code1");
         result.Messages.First().Variables.Should().HaveCount(2);
         result.Messages.First().Variables.First().Name.Should().Be("var1");
         result.Messages.First().Variables.Last().Value.Should().Be("value2");

         result.IsValid.Should().Be(true);
      }

      /// <summary>Validate Generic Result thats return data</summary>
      [Fact]
      public void ResultGeneric_ValidadeDataWithValue_ShouldRetunData()
      {
         var result = new Result<int>(20);

         result.Message.Should().BeNull();
         result.HasData.Should().Be(true);
         result.HasErrorOrDataIsNull.Should().Be(false);
         result.HasError.Should().Be(false);
         result.HasWarning.Should().Be(false);
         result.Messages.Should().HaveCount(0);
         result.IsValid.Should().Be(true);
         result.Data.Should().Be(20);
      }

      /// <summary>Validate Generic Result thats doesn't have data</summary>
      [Fact]
      public void ResultGeneric_ValidadeDataWithoutValue_ShouldDontRetunData()
      {
         var result = new Result<string>();

         result.Message.Should().BeNull();
         result.HasData.Should().Be(false);
         result.HasErrorOrDataIsNull.Should().Be(true);
         result.HasError.Should().Be(false);
         result.HasWarning.Should().Be(false);
         result.Messages.Should().HaveCount(0);
         result.IsValid.Should().Be(true);
         result.Data.Should().BeNull();
      }
   }
}
