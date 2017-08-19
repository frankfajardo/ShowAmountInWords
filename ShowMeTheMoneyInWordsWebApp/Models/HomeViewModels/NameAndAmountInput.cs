using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShowMeTheMoneyInWordsWebApp
{
    public class NameAndAmountInput
    {
        [Required]
        [RegularExpression(@"^.*\""(\d+(\.\d{0,2})?)\""$", 
            ErrorMessage = "Value does not match the required format.")]
        [Display(Name = "Name and amount")]
        public string NameAndAmount { get; set; }
    }
}
