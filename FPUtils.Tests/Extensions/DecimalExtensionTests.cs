using FluentAssertions;
using FPUtils.Extensions;
using Xunit;

namespace FPUtils.Tests.Extensions
{
   /// <summary>
   /// Tests for Decimal type extensions
   /// </summary>
   public class DecimalExtensionTests
   {
      /// <summary> Validate if the value is EQUAL zero </summary>
      [Theory]
      [InlineData("0.001", false)]
      [InlineData("-0.0001", false)]
      [InlineData("50", false)]
      [InlineData("-1", false)]
      [InlineData("0", true)]
      public void EqualZero(string value, bool expected)
      {
         var decimalValue = decimal.Parse(value);
         var result = DecimalExtension.EqualZero(decimalValue);
         result.Should().Be(expected);
      }

      /// <summary> Validate if the value is GREATER THAN zero </summary>
      [Theory]
      [InlineData("0.001", true)]
      [InlineData("-0.0001", false)]
      [InlineData("50", true)]
      [InlineData("-1", false)]
      [InlineData("0", false)]
      public void GreaterThanZero(string value, bool expected)
      {
         var decimalValue = decimal.Parse(value);
         var result = DecimalExtension.GreaterThanZero(decimalValue);
         result.Should().Be(expected);
      }

      /// <summary> Validate if the value is GREATER THAN OR EQUAL zero </summary>
      [Theory]
      [InlineData("0.001", true)]
      [InlineData("-0.0001", false)]
      [InlineData("50", true)]
      [InlineData("-1", false)]
      [InlineData("0", true)]
      public void GreaterThanOrEqualZero(string value, bool expected)
      {
         var decimalValue = decimal.Parse(value);
         var result = DecimalExtension.GreaterThanOrEqualZero(decimalValue);
         result.Should().Be(expected);
      }

      /// <summary> Validate if the value is LESS THAN zero </summary>
      [Theory]
      [InlineData("0.001", false)]
      [InlineData("-0.0001", true)]
      [InlineData("50", false)]
      [InlineData("-1", true)]
      [InlineData("0", false)]
      public void LessThanZero(string value, bool expected)
      {
         var decimalValue = decimal.Parse(value);
         var result = DecimalExtension.LessThanZero(decimalValue);
         result.Should().Be(expected);
      }

      /// <summary> Validate if the value is LESS THAN OR EQUAL zero </summary>
      [Theory]
      [InlineData("0.001", false)]
      [InlineData("-0.0001", true)]
      [InlineData("50", false)]
      [InlineData("-1", true)]
      [InlineData("0", true)]
      public void LessThanOrEqualZero(string value, bool expected)
      {
         var decimalValue = decimal.Parse(value);
         var result = DecimalExtension.LessThanOrEqualZero(decimalValue);
         result.Should().Be(expected);
      }

      /// <summary> Validate when receive a NULL value </summary>
      [Fact]
      public void ValidateNullValues()
      {
         var result = DecimalExtension.EqualZero(null);
         result.Should().Be(false);

         result = DecimalExtension.GreaterThanZero(null);
         result.Should().Be(false);

         result = DecimalExtension.GreaterThanOrEqualZero(null);
         result.Should().Be(false);

         result = DecimalExtension.LessThanZero(null);
         result.Should().Be(false);

         result = DecimalExtension.LessThanOrEqualZero(null);
         result.Should().Be(false);
      }
   }
}
