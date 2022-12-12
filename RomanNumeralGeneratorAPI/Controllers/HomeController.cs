using Microsoft.AspNetCore.Mvc;
using RomanNumeralGenerator;
using RomanNumeralGenerator.Services;

namespace RomanNumeralGeneratorAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogHistoryService _history;

        public HomeController(ILogHistoryService history)
        {
            _history = history;
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LogHistory log)
        {
            if (log.Input is > 0 and < 4000)
            {
                //_romanConverter.AddLog(log);
                _history.AddLog(log);
                TempData["converted"] = $"{log.Input} in Roman numerals is {log.Output}";
            }
            return View();
        }

        public IActionResult History()
        {
            IEnumerable<LogHistory> history = _history.GetAll();
            return View(history.Reverse());
        }
    }
}
