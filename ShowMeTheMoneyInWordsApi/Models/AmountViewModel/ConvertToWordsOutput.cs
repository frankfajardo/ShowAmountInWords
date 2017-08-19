using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowMeTheMoneyInWordsApi.Models.AmountViewModel
{
    /// <summary>
    /// Represents the conversion output of a decimal amount into words
    /// </summary>
    public class ConvertToWordsOutput
    {
        /// <summary>
        /// The amount to convert
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Indicates if the conversion is successful
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Contais the words if the conversion is successful
        /// </summary>
        public string Words { get; set; }
    }
}
