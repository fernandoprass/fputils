using FluentAssertions;
using FPUtils.Response;
using System.Linq;
using Xunit;

namespace FPUtils.Tests.Response
{
   /// <summary>
   /// Tests for Result class
   /// </summary>
   public class MessageTests
   {
      /// <summary>Validate Result with messages wtih variables</summary>
      [Theory]
      [InlineData("code1", "the var1 and the var2", "the value1 and the value2")]
      [InlineData("code1", "the {var1} and the {var2}", "the value1 and the value2")]
      [InlineData("code1", "the [var1] and the [var2]", "the value1 and the value2")]

      public void Show_MessageWitVariables_ShouldParse(string code, string text, string expected)
      {
         var message = new InformationMessage(code, text);
         message.AddVariable("var1", "value1");
         message.AddVariable("var2", "value2");

         message.Code.Should().Be(code);
         message.Text.Should().Be(text); 

         var result = message.Show();

         result.Should().Be(expected);
      }

      [Fact]
      public void Show_MessageWitoutVariables_ShouldShowText()
      {
         string code = "code1";
         string text = "the text";
         var message = new ErrorMessage(code, text);

         message.Code.Should().Be(code);
         message.Text.Should().Be(text);

         var result = message.Show();

         result.Should().Be(text);
      }
   }
}
