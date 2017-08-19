using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ShowMeTheMoneyInWordsWebApp.Models.Settings;


namespace ShowMeTheMoneyInWordsWebApp.Orchestrators
{
    public class HomeOrchestrator
    {
        private AmountInWordsApiSettings apiSettings;
        private static readonly HttpClient httpClient = new HttpClient();

        public HomeOrchestrator(AmountInWordsApiSettings apiSettings)
        {
            this.apiSettings = apiSettings;
            httpClient.BaseAddress = new Uri(apiSettings.BaseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(apiSettings.AcceptMediaType));
        }

        public async Task<string> ProcessInput(string input)
        {
            return await httpClient.GetStringAsync(string.Format(apiSettings.EndPoint, input));
        }
    }
}
