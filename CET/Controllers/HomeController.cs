using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CET.Models;
using CET.Services;

namespace CET.Controllers
{
    public class HomeController : Controller
    {
		private ITicketData _ticketData;
		public HomeController(ITicketData ticketData)
		{
			_ticketData = ticketData;
		}
        public IActionResult Index()
        {
			var model = _ticketData.GetAll();
            return View(model);
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
