using Microsoft.AspNetCore.Mvc;
using NewArea_Core.Models;
using System.Diagnostics;

namespace NewArea_Core.Controllers
{
    public class NewAreaController : Controller
    {
        private readonly ILogger<NewAreaController> _logger;

        public NewAreaController(ILogger<NewAreaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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