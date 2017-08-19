using System;
using System.Text.RegularExpressions;

namespace ShowMeTheMoneyInWordsApi.Helpers
{
    /// <summary>
    /// Provides extension methods for
    /// </summary>
    public static class StringExtensionMethods
    {
        public const string AmountRegexPattern = @"(\b\d+(\.\d{0,2})?\b)";

        /// <summary>
        /// Extracts the first amount value from a text
        /// </summary>
        /// <param name="text">The text to extract from</param>
        /// <returns>
        /// A flag that indicates the text has an amount in it; 
        /// and if there is, the captured amount substring and the decimal value of that amount.
        /// </returns>
        public static (bool Success, string Capture, decimal Amount) ExtractAmount(this string text)
        {
            Regex amt = new Regex(AmountRegexPattern);
            var mx = amt.Match(text);
            if (mx.Success)
            {
                decimal amount;
                if (decimal.TryParse(mx.Value, out amount))
                {
                    return (true, mx.Value, amount);
                }
            }
            return (false, null, 0m);
        }
    }
}
