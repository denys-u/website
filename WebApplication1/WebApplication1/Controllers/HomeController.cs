using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Entyties;
using WebApplication1.Providers.Abstractions;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGameProvider _provider;
        public HomeController(ILogger<HomeController> logger, IGameProvider provider)
        {
            _provider = provider;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult AddGame()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGame(string name, double price, string genre, string developer)
        {
            string authData = $"Game: {name} Price: {price}, Genre: {genre}, Developer: {developer}";
            return Content(authData);
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
