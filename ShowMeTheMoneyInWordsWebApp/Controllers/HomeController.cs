using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShowMeTheMoneyInWordsWebApp.Orchestrators;

namespace ShowMeTheMoneyInWordsWebApp.Controllers
{
    public class HomeController : Controller
    {
        private HomeOrchestrator orchestrator;

        public HomeController(HomeOrchestrator orchestrator)
        {
            if (orchestrator == null)
                throw new ArgumentException();
            this.orchestrator = orchestrator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(NameAndAmountInput input)
        {
            if (!ModelState.IsValid)
                return View();

            ViewData["Message"] = await orchestrator.ProcessInput(input.NameAndAmount);
            return View("Result");
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
