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
      /// <summary>Validate without messages and with data</summary>
      [Fact]
      public void Result_WithStringMessage_ShouldBeValid()
      {
         string message = "text message";
         var result = new Result(message);

         result.Message.Should().Be(message);
         result.HasError.Should().Be(false);
         result.HasWarning.Should().Be(false);
         result.HasMessage.Should().Be(false);
         result.Messages.Should().HaveCount(0);
         result.IsValid.Should().Be(true);
      }

      /// <summary>Validate without messages and with data</summary>
      [Fact]
      public void Result_WithoutMessagesAndWithData_ShouldRetunDataAndBeValid()
      {
         var result = new Result<int>(20);

         result.Message.Should().BeNull();
         result.HasData.Should().Be(true);
         result.HasErrorOrDataIsNull.Should().Be(false);
         result.HasError.Should().Be(false);
         result.HasWarning.Should().Be(false);
         result.HasMessage.Should().Be(false);
         result.Messages.Should().HaveCount(0);
         result.IsValid.Should().Be(true);
         result.Data.Should().Be(20);
      }

      /// <summary>Validate without messages and without data</summary>
      [Fact]
      public void Result_WithoutMessagesAndWithoutData_ShouldRetunDataAndBeValid()
      {
         var result = new Result<string>();

         result.Message.Should().BeNull();
         result.HasData.Should().Be(false);
         result.HasErrorOrDataIsNull.Should().Be(true);
         result.HasError.Should().Be(false);
         result.HasWarning.Should().Be(false);
         result.HasMessage.Should().Be(false);
         result.Messages.Should().HaveCount(0);
         result.IsValid.Should().Be(true);
         result.Data.Should().BeNull();
      }

      /// <summary>Validate result with error messages</summary>
      [Fact]
      public void Result_WithErrorMessages_ShouldBeInvalid()
      {
         var errorMessage = new ErrorMessage("code1","error1" );

         var result = new Result();
         result.AddMessage(errorMessage);

         result.Message.Should().BeNull();
         result.HasError.Should().Be(true);
         result.HasWarning.Should().Be(false);
         result.HasMessage.Should().Be(true);
         result.Messages.Should().HaveCount(1);
         result.Messages.First().Should().BeOfType<ErrorMessage>();
         result.Messages.First().Code.Should().Be("code1");
         result.Messages.First().Text.Should().Be("error1");

         result.IsValid.Should().Be(false);
      }

      /// <summary>Validate result with warning messages</summary>
      [Fact]
      public void Result_WithWarningMessagess_ShouldBeValid()
      {
         var warningMessage = new WarningMessage("code1", "warning1");

         var result = new Result(warningMessage);

         result.Message.Should().BeNull();
         result.HasError.Should().Be(false);
         result.HasWarning.Should().Be(true);
         result.HasMessage.Should().Be(true);
         result.Messages.Should().HaveCount(1);
         result.Messages.First().Should().BeOfType<WarningMessage>();
         result.IsValid.Should().Be(true);
      }

      /// <summary>Validate result with information messages</summary>
      [Fact]
      public void Result_WithInformationMessages_ShouldBeValid()
      {
         var infoMessage = new InformationMessage("code1", "info1");

         var result = new Result(infoMessage);

         result.Message.Should().BeNull();
         result.HasError.Should().Be(false);
         result.HasWarning.Should().Be(false);
         result.HasMessage.Should().Be(true);
         result.Messages.Should().HaveCount(1);
         result.Messages.First().Should().BeOfType<InformationMessage>();

         result.IsValid.Should().Be(true);
      }

      /// <summary>Validate Result with multiple type of messages</summary>
      [Fact]
      public void Result_WithMultipleTypesOfMessages_ShouldBeInvalid()
      {
         var errorMessage = new ErrorMessage("code1", "error1");
         var warningMessage = new WarningMessage("code2", "warning1");
         var infoMessage = new InformationMessage("code3", "information1");

         var result = new Result();
         result.AddMessage(errorMessage);
         result.AddMessage(warningMessage);
         result.AddMessage(infoMessage);

         result.Message.Should().BeNull();
         result.HasError.Should().Be(true);
         result.HasWarning.Should().Be(true);
         result.HasMessage.Should().Be(true);
         result.Messages.Should().HaveCount(3);
      }
   }
}
