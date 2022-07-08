using FluentAssertions;
using FPUtils.Extensions;
using System;
using Xunit;

namespace FPUtils.Tests.Extensions {
   /// <summary>
   /// Tests for DateTime type extensions
   /// </summary>
   public class StringExtensionTests
   {
      /// <summary>
      /// Remove letters and simbols, keeping only numbers
      /// </summary>
      /// <param name="value"></param>
      /// <param name="expected"></param>
      [Theory]
      [InlineData("123","123")]
      [InlineData("a1b2c3","123")]
      [InlineData("1 2.3,4a5b","12345")]
      [InlineData(" 1·2-3Ò4Z5?", "12345")]
      [InlineData("abc", "")]
      [InlineData("", "")]
      [InlineData(null,null)]
      public void KeepOnlyNumbers(string value, string expected) {
         var result = value.KeepOnlyNumbers();
         result.Should().Be(expected);
      }

      /// <summary>
      /// Remove simbols keeping only numbers and letters
      /// </summary>
      /// <param name="value"></param>
      /// <param name="expected"></param>
      [Theory]
      [InlineData("123", "123")]
      [InlineData("a1b2c3", "a1b2c3")]
      [InlineData("1 2.3,45_ab", "12345ab")]
      [InlineData(" 1·2-3Ò4Z5?", "1·23Ò4Z5")]
      [InlineData("abc", "abc")]
      [InlineData("", "")]
      [InlineData(null, null)]
      public void KeepOnlyNumbersAndLetters(string value, string expected) {
         var result = value.KeepOnlyNumbersAndLetters();
         result.Should().Be(expected);
      }


      /// <summary>
      /// Remove simbols keeping only numbers, letters and spaces
      /// </summary>
      /// <param name="value"></param>
      /// <param name="expected"></param>
      [Theory]
      [InlineData("123", "123")]
      [InlineData("a1 b2 c3", "a1 b2 c3")]
      [InlineData("1 2.3,45_ab", "1 2345ab")]
      [InlineData(" 1·2-3Ò4 Z5?", " 1·23Ò4 Z5")]
      [InlineData("abc", "abc")]
      [InlineData("", "")]
      [InlineData(null, null)]
      public void KeepOnlyNumbersAndLettersAndSpaces(string value, string expected) {
         var result = value.KeepOnlyNumbersAndLettersAndSpaces();
         result.Should().Be(expected);
      }

      /// <summary>
      /// Remove accents
      /// </summary>
      /// <param name="value"></param>
      /// <param name="expected"></param>
      [Theory]
      [InlineData("123a", "123a")]
      [InlineData("·1È2Ì3Û˙", "a1e2i3ou")]
      [InlineData("·ÈÌÛ˙ ¡…Õ”⁄ „√ı’ Á«.Ò—", "aeiou AEIOU aAoO cC.nN")]
      [InlineData("aeiou AEIOU", "aeiou AEIOU")]
      [InlineData("", "")]
      [InlineData(null, null)]
      public void RemoveAccents(string value, string expected) {
         var result = value.RemoveAccents();
         result.Should().Be(expected);
      }

   }
}
