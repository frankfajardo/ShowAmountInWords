using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowMeTheMoneyInWordsApi.Models.AmountViewModel
{
    /// <summary>
    /// Represents the extraction output of a decimal amount from within a text
    /// </summary>
    public class ExtractAmountOutput
    {
        /// <summary>
        /// Input text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Indicates if the extraction is successful
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// The captured string that indicates the amount
        /// </summary>
        public string Capture { get; set; }
        /// <summary>
        /// The extracted amount
        /// </summary>
        public decimal Amount { get; set; }
    }
}
