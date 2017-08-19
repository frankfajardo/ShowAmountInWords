using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShowMeTheMoneyInWordsApi.Models.AmountViewModel;
using ShowMeTheMoneyInWordsApi.Helpers;

namespace ShowMeTheMoneyInWordsApi.Controllers
{
    [Route("api/[controller]")]
    public class AmountController : Controller
    {
        //[HttpGet("{amount}/inwords")]
        //public ConvertToWordsOutput ConvertToWords(decimal amount)
        //{
        //    ConvertToWordsOutput output = new ConvertToWordsOutput();
        //    try
        //    {
        //        output.Amount = amount;
        //        output.Words = amount.ToDollarsAndCentsWords();
        //        output.Success = true;
        //    }
        //    catch
        //    {
        //        // Logging can be done here
        //    }
        //    return output;
        //}

        //[HttpGet("extractfrom")]
        //public ExtractAmountOutput ExtractAmount(string text)
        //{
        //    var result = text.ExtractAmount();
        //    return new ExtractAmountOutput
        //    {
        //        Text = text,
        //        Success = result.Success,
        //        Amount = result.Amount
        //    };
        //}

        [HttpGet("inwords")]
        public string ExtractAndConvertToWords(string text)
        {
            var result = string.Empty;
            var extract = text.ExtractAmount();
            if (extract.Success)
            {
                var amountStr = extract.Capture;
                try
                {
                    var words = extract.Amount.ToDollarsAndCentsWords();
                    result = text.Replace(amountStr, words);
                }
                catch
                {
                    // Logging can be done here
                }
            }
            return result;
        }
    }
}
