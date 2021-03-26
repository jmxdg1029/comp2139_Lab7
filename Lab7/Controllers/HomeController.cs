using Lab7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7.Controllers
{
    public class HomeController : Controller
    {

        public TripLogContext context { get; set; }
        public HomeController(TripLogContext ctx) => context = ctx;
        public ViewResult Index()
        {
            var trips = context.Trips.OrderBy(t => t.startDate).ToList();
            return View(trips);

        }

    }
}
