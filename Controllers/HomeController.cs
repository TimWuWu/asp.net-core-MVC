using Microsoft.AspNetCore.Mvc;
using MyresumeWebApplication.Data;
using MyresumeWebApplication.Models;
using System.Diagnostics;

namespace MyresumeWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyresumeInfoContext _context;

        public HomeController(ILogger<HomeController> logger, MyresumeInfoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}