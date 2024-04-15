using Microsoft.AspNetCore.Mvc;
using MVCFRIB.Models;
using MVCFRIB.Data;
using System.Diagnostics;

namespace MVCFRIB.Controllers
{
    public class HomeController : Controller
    {
        private readonly MessageContext _context;

        public HomeController(MessageContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //return View(_context.Messages.ToList());
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
