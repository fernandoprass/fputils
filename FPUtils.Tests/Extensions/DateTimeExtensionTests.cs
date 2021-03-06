using FluentAssertions;
using FPUtils.Extensions;
using System;
using Xunit;

namespace FPUtils.Tests.Extensions 
 {
   /// <summary>
   /// Tests for DateTime type class extensions
   /// </summary>
   public class DateTimeExtensionTests
   {
      /// <summary>  Received a date and return the first day of the month </summary>
      [Fact]
      public void FirstDayOfMonth()
      {
         var result = DateTimeExtension.FirstDayOfMonth(DateTime.Today);
         result.Year.Should().Be(DateTime.Today.Year);
         result.Month.Should().Be(DateTime.Today.Month);
         result.Day.Should().Be(1);
      }

      /// <summary>
      /// Validate LastDayOfMonth for Leap and No Leap Years
      /// </summary>
      /// <param name="year"></param>
      /// <param name="month"></param>
      /// <param name="day"></param>
      /// <param name="expectedDay"></param>
      [Theory]
      [InlineData(2020, 01, 01, 31)]
      [InlineData(2021, 04, 30, 30)]
      [InlineData(2022, 07, 12, 31)]
      [InlineData(2023, 09, 28, 30)]
      [InlineData(2024, 12, 31, 31)]
      public void LastDayOfMonthGeneralValidations(int year, int month, int day, int expectedDay) {
         var result = DateTimeExtension.LastDayOfMonth(new DateTime(year, month, day));
         result.Year.Should().Be(year);
         result.Month.Should().Be(month);
         result.Day.Should().Be(expectedDay);
      }


      /// <summary>
      /// Validate LastDayOfMonth for Leap and No Leap Years
      /// </summary>
      /// <param name="year"></param>
      /// <param name="month"></param>
      /// <param name="day"></param>
      /// <param name="expectedDay"></param>
      [Theory]
      [InlineData(2020, 02, 01, 29)]
      [InlineData(2021, 02, 01, 28)]
      [InlineData(2022, 02, 12, 28)]
      [InlineData(2023, 02, 28, 28)]
      [InlineData(2024, 02, 28, 29)]
      public void LastDayOfMonthLeapYear(int year, int month, int day, int expectedDay) {
         var result = DateTimeExtension.LastDayOfMonth(new DateTime(year, month, day));
         result.Year.Should().Be(year);
         result.Month.Should().Be(month);
         result.Day.Should().Be(expectedDay);
      }
   }
}
