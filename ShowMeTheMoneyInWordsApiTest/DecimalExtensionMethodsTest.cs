using System;
using Xunit;
using ShowMeTheMoneyInWordsApi.Helpers;

namespace ShowMeTheMoneyInWordsApiTest
{
    public class DecimalExtensionMethodsTest
    {
        [Fact]
        public void ToDollarsAndCentsWords_ShouldThrowAORException_WhenAmountBelowZero()
        {
            var negativeAmount = -3.50m;
            var exception = Record.Exception(() => DecimalExtensionMethods.ToDollarsAndCentsWords(negativeAmount));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentOutOfRangeException>(exception);
        }

        [Theory]
        [InlineData(123.1, "ONE HUNDRED AND TWENTY-THREE DOLLARS AND TEN CENTS")]
        [InlineData(0.55, "ZERO DOLLARS AND FIFTY-FIVE CENTS")]
        [InlineData(86.00, "EIGHTY-SIX DOLLARS AND ZERO CENTS")]
        public void ToDollarsAndCentsWords_ShouldReturnCorrectWords_WhenAmountIsNotBelowZero(decimal amount, string expectedWords)
        {
            // Act
            var result = amount.ToDollarsAndCentsWords();
            // Assert
            Assert.Equal(expectedWords, result);
        }
    }
}
