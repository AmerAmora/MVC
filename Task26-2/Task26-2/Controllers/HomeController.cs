using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Task26_2.Models;

namespace Task26_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CoreTaskContext _context;


        
        public HomeController(ILogger<HomeController> logger, CoreTaskContext context)
        {
            _logger = logger;
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Cliniccs.ToListAsync());
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Doctors(int id)
        {
            var coreTaskContext = _context.Doctors.Where(x=>x.ClinicId==id).Include(d => d.Clinic).ToList();

            return View(coreTaskContext);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}