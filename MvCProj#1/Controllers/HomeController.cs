using Microsoft.AspNetCore.Mvc;
using MvCProj_1.Models;
using System.Diagnostics;
using System.Text.Encodings.Web;

namespace MvCProj_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //with Query String
        public IActionResult Welcome(string Name,int Numtimes)
        {
            ViewData["NumTimes"] = Numtimes;
            ViewData["Message"] = Name;
            return View();
        }

        //with Parameters in url
        public string Welcome1(string Name,int id=1)
        {
            return HtmlEncoder.Default.Encode($"{Name} with {id}");
        }
        //Uses HtmlEncoder.Default.Encode to protect the app from malicious input, such as through JavaScript.
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
