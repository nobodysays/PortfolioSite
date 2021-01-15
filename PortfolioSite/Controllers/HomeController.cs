using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortfolioSite.App.Services;
using PortfolioSite.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioSite.Controllers
{
    public class HomeController : Controller
    {
        private RecordTableService _recordTableService;

        public HomeController(RecordTableService recordTableService)
        {
            _recordTableService = recordTableService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Projects()
        {
            return View();
        }
        public IActionResult Records(string? game)
        {
            if (game == null)
                return NotFound();
            return View(_recordTableService.GetRecordTableForGame(game));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
