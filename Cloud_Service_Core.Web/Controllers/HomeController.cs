using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cloud_Service_Core.Web.Models;
using Microsoft.Extensions.Configuration;

namespace Cloud_Service_Core.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //var vr = configuration["Movies:ServiceApiKey"];

            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return View("~/Views/Account/Login_.cshtml");
            }

            //  to correct
            var name = HttpContext.User.Identity.Name;

            return RedirectToAction("DisplayFiles", "File", new { folder = name });
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
