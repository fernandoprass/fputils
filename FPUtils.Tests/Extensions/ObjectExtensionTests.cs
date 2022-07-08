using FluentAssertions;
using FPUtils.Extensions;
using Xunit;

namespace FPUtils.Tests.Extensions {
   /// <summary>
   /// Tests for Object type extensions
   /// </summary>
   public class ObjectExtensionTests
   {
      /// <summary> Check if the object is NULL </summary>
      [Fact]
      public void IsNull()
      {
         object obj = null;
         var result = ObjectExtensions.IsNull(obj);
         result.Should().Be(true);

         obj = new object();
         result = ObjectExtensions.IsNull(obj);
         result.Should().Be(false);
      }

      /// <summary> Check if the object is NULL </summary>
      [Fact]
      public void IsNotNull()
      {
         object obj = null;
         var result = ObjectExtensions.IsNotNull(obj);
         result.Should().Be(false);

         obj = new object();
         result = ObjectExtensions.IsNotNull(obj);
         result.Should().Be(true);
      }
   }
}
