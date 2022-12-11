using Microsoft.AspNetCore.Mvc;
using RomanNumeralGenerator;
using RomanNumeralGenerator.Data;

namespace RomanNumeralGeneratorAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly RomanNumeralGeneratorDbContext _context;
        private readonly Generator _generator;

        public HomeController(RomanNumeralGeneratorDbContext context, Generator generator)
        {
            _context = context;
            _generator = generator;
        }
        public IActionResult About()
        {
            return View();
        }

        //GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            IEnumerable<LogHistory> history = _context.History;
            return View(history.Reverse());
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate(LogHistory log)
        {
            if(log.Input is > 1 and <3999)
            {
                log.Time = DateTime.Now.ToString();
                log.Output = _generator.Generate(log.Input);
                _context.History.Add(log);
                _context.SaveChanges();
            }
            return View();
        }
    }
}
