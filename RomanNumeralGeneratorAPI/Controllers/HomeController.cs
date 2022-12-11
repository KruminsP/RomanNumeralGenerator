using Microsoft.AspNetCore.Mvc;
using RomanNumeralGenerator;
using RomanNumeralGenerator.Data;

namespace RomanNumeralGeneratorAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly RomanConverterService _romanConverter;

        public HomeController(RomanConverterService romanConverter)
        {
            _romanConverter = romanConverter;
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
            if(log.Input is > 0 and < 4000)
            {
                _romanConverter.AddLog(log);
                TempData["converted"] = $"{log.Input} in Roman numerals is {log.Output}";
            }
            return View();
        }

        //GET
        public IActionResult History()
        {
            IEnumerable<LogHistory> history = _romanConverter.History;
            return View(history.Reverse());
        }
    }
}
