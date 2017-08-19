using System;
using System.Collections.Generic;
using Xunit;
using ShowMeTheMoneyInWordsApi.Helpers;

namespace ShowMeTheMoneyInWordsApiTest
{
    public class StringExtensionMethodTest
    {
        [Theory]
        [InlineData("John Smith")]
        [InlineData(@"John Smith a1")]
        public void ExtractAmount_ShouldReturnFalse_WhenTextHasNoValidDollarAmount(string text)
        {
            var result = text.ExtractAmount();
            Assert.False(result.Success);
        }

        [Theory]
        [MemberData(nameof(GetTextWithDollarAmounts))]
        public void ExtractAmount_ShouldReturnTrue_WhenTextHasDollarAmount(string text, decimal expectedAmount)
        {
            var result = text.ExtractAmount();
            Assert.True(result.Success);
            Assert.Equal(expectedAmount, result.Amount);
        }


        public static IEnumerable<object[]> GetTextWithDollarAmounts()
        {
            yield return new object[]
            {
                "John Smith 3.99",
                3.99m
            };
            yield return new object[]
            {
                @"John Smith ""650.1""",
                650.10m
            };
            yield return new object[]
            {
                @"John Smith ""0.15""",
                0.15m
            };
        }
    }
}
