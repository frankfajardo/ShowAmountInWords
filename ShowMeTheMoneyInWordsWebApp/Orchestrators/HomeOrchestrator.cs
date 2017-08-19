using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ShowMeTheMoneyInWordsWebApp.Models.Settings;


namespace ShowMeTheMoneyInWordsWebApp.Orchestrators
{
    public class HomeOrchestrator
    {
        private ApiUrlSettings urlSettings;

        public HomeOrchestrator(ApiUrlSettings urlSettings)
        {
            this.urlSettings = urlSettings;
        }

        public async Task<string> ProcessInput(string input)
        {
            var client = new HttpClient();
            return await client.GetStringAsync(urlSettings.AmountInWordsApi + "?text=" + input);
        }
    }
}
