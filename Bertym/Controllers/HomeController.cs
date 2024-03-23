using Bertym.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebApplication1.Models;

namespace Bertym.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<ListDemo> _listDemo;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            _listDemo = new List<ListDemo>
                {
                new() { ListItemValue=1, ListItemText="Item 1"},
                new() { ListItemValue=2, ListItemText="Item 2"},
                new() { ListItemValue=3, ListItemText="Item 3"}
                };
        }

        public IActionResult Index()
        {
            ViewData["Text"] = "Лабораторная работа 2";
            ViewData["Lst"] = new SelectList(_listDemo, "ListItemValue", "ListItemText");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}