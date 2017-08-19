using System;
using Humanizer;

namespace ShowMeTheMoneyInWordsApi.Helpers
{
    /// <summary>
    /// Provides extension methods for decimal type.
    /// </summary>
    public static class DecimalExtensionMethods
    {
        /// <summary>
        /// Converts a decimal amount to words in uppercase
        /// </summary>
        /// <returns>A string with the amount in words in uppercase</returns>
        /// <exception cref="ArgumentOutOfRangeException">When amount is below zero.</exception>
        public static string ToDollarsAndCentsWords(this decimal amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("Amount cannot be below zero.");
            int dollars = (int)amount;
            int cents = (int)((amount - dollars) * 100);
            return ($"{dollars.ToWords()} dollars and {cents.ToWords()} cents").Transform(To.UpperCase);
        }
    }
}
