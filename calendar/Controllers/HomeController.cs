using calendar.Data;
using calendar.Models;
using calendar.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace calendar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDAL _idal;
        private readonly UserManager<User> _userManager;


        public HomeController(ILogger<HomeController> logger, IDAL idal, UserManager<User> userManager)
        {
            _logger = logger;
            _idal = idal;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(_idal.GetLocations());
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(_idal.GetEvents());
            return View();
        }

        [Authorize]
        public IActionResult MyCalendar()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(_idal.GetLocations());
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(_idal.GetMyEvents(userid));
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
