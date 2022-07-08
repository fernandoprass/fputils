using FluentAssertions;
using FPUtils.Security;
using Xunit;

namespace FPUtils.Tests.Security
{
   public class CryptographyTests
   {
      /// <summary>
      /// Encrypt a string
      /// </summary>
      /// <param name="value">The string value</param>
      /// <param name="Key">The encryption key</param>
      /// <param name="expected">The expected result</param>
      [Theory]
      [InlineData("123", "key", "+kw1OUJGpZI=")]
      [InlineData("a1b2c3", "key", "wtlKyH6IOc0=")]
      [InlineData("á é í ó u AEIOU", "myKey", "09m0laa2gJsJnUDBCy94Q6lHsZJP+cby")]
      [InlineData("", "", "")]
      [InlineData(null, null, null)]
      public void Encrypt(string value, string key, string expected) {
         var result = Cryptography.Encrypt(value, key);
         result.Should().Be(expected);
      }

      /// <summary>
      /// Decrypt a string
      /// </summary>
      /// <param name="value">The string value</param>
      /// <param name="Key">The decryption key</param>
      /// <param name="expected">The expected result</param>
      [Theory]
      [InlineData("+kw1OUJGpZI=", "key", "123")]
      [InlineData("wtlKyH6IOc0=", "key", "a1b2c3")]
      [InlineData("09m0laa2gJsJnUDBCy94Q6lHsZJP+cby", "myKey", "á é í ó u AEIOU")]
      [InlineData("", "", "")]
      [InlineData(null, null, null)]
      public void Decrypt(string value, string key, string expected)
      {
         var result = Cryptography.Decrypt(value, key);
         result.Should().Be(expected);
      }
   }
}
