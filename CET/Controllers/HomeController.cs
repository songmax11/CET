using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CET.Models;
using CET.Services;
using CET.ViewModel;

namespace CET.Controllers
{
    public class HomeController : Controller
    {
        private IChangeLoggerData _changeLoggerData;
        private ITicketData _ticketData;
        private IGreeter _greeter;

        public HomeController(IChangeLoggerData changeLoggerData, ITicketData ticketData, IGreeter greeter)
        {
            _changeLoggerData = changeLoggerData;
            _ticketData = ticketData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                Tickets = _ticketData.GetAll(),
                WelcomeMessage = _greeter.GetWelcomeMessage()
            };

            return View(model);
        }

        public IActionResult Search(string searchText)
        {
            var model = new SearchViewModel
            {
                Tickets = _ticketData.Search(searchText),
                SearchText = searchText
            };

            return View(model);
        }

        public IActionResult ChangeHistory()
        {
            var model = new ChangeLoggerHistory
            {
                ChangeLoggers = _changeLoggerData.GetAll()
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _ticketData.Get(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = _ticketData.Get(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(TicketCreateModel model)
        {
            var newTicket = new Ticket
            {
                Application = model.App,
                TicketType = model.Type,
                Urgency = model.Urgency
            };

            newTicket = _ticketData.Add(newTicket);
            return RedirectToAction(nameof(Details), new { id = newTicket.Id });
        }

        [HttpPost]
        public IActionResult Update(TicketUpdateModel model)
        {
            _ticketData.Update(model);

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
