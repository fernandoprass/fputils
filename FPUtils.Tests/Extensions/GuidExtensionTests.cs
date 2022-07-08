using FluentAssertions;
using FPUtils.Extensions;
using System;
using Xunit;

namespace FPUtils.Tests.Extensions {
   /// <summary>
   /// Tests for Guid type class extensions
   /// </summary>
   public class GuidExtensionTests
   {
      /// <summary> Received a null value and return TRUE </summary>
      [Fact]
      public void IsEmpty_ReceivedNull_ReturnTrue()
      {
         var result = GuidExtension.IsEmpty(null);
         result.Should().Be(true);
      }

      /// <summary> Received a guid and return FALSE </summary>
      [Fact]
      public void IsEmpty_ReceivedGuid_ReturnFalse() {
         var result = GuidExtension.IsEmpty(Guid.NewGuid());
         result.Should().Be(false);
      }

      /// <summary> Received an empty guid and return TRUE </summary>
      [Fact]
      public void IsEmpty_ReceivedEmptyGuid_ReturnTrue() {
         var result = GuidExtension.IsEmpty(Guid.Empty);
         result.Should().Be(true);
      }

      /// <summary> Received a null value and return FALSE </summary>
      [Fact]
      public void IsNotEmpty_ReceivedNull_ReturnFalse() {
         var result = GuidExtension.IsNotEmpty(null);
         result.Should().Be(false);
      }

      /// <summary> Received an empty guid and return FALSE </summary>
      [Fact]
      public void IsNotEmpty_ReceivedEmptyGuid_ReturnFalse() {
         var result = GuidExtension.IsNotEmpty(Guid.Empty);
         result.Should().Be(false);
      }

      /// <summary> Received a guid and return TRUE </summary>
      [Fact]
      public void IsNotEmpty_ReceivedGuid_ReturnTrue() {
         var result = GuidExtension.IsNotEmpty(Guid.NewGuid());
         result.Should().Be(true);
      }

   }
}
