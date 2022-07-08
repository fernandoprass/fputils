using FluentAssertions;
using FPUtils.Extensions;
using System.Collections.Generic;
using Xunit;

namespace FPUtils.Tests.Extensions {
   /// <summary>
   /// Tests for IEnumerable type class extensions
   /// </summary>
   public class EnumerableExtensionTests
   {
      /// <summary> Receive an uninstantiated list and return False </summary>
      [Fact]
      public void HasData_ReceiveUninstantiatedList_ReturnFalse()
      {
         List<int> lista = null;
         var result = EnumerableExtensions.HasData(lista);
         result.Should().Be(false);
      }

      /// <summary> Receive an empty list and return False </summary>
      [Fact]
      public void HasData_ReceiveEmptyList_ReturnFalse()
      {
         var lista = new List<int>();
         var result = EnumerableExtensions.HasData(lista);
         result.Should().Be(false);
      }

      /// <summary> Receive a list with elements and return True </summary>
      [Fact]
      public void HasData_ReceiveListWithValues_RetornTrue()
      {
         var lista = new List<int> { 1 };
         var result = EnumerableExtensions.HasData(lista);
         result.Should().Be(true);
      }
   }
}
