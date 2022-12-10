using Microsoft.AspNetCore.Mvc;
using RomanNumeralGenerator;
using RomanNumeralGenerator.Data;

namespace RomanNumeralGeneratorAPI.Controllers
{
    public class RomanNumeralGeneratorController : Controller
    {
        private readonly RomanNumeralGeneratorDbContext _context;

        public RomanNumeralGeneratorController(RomanNumeralGeneratorDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<LogHistory> history = _context.History;
            return View(history);
        }
    }
}
