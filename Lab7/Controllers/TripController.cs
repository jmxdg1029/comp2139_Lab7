using Lab7.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7.Controllers
{
    public class TripController : Controller
    {
        public TripLogContext context { get; set; }
        public TripController(TripLogContext ctx) => context = ctx;
        public RedirectToActionResult Cancel()
        {
            TempData.Clear();
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public ViewResult Add(string id = "")
        {
            var vm = new TripViewModel();
            if(id == "Page2")
            {
                var accomodation = TempData[nameof(Trip.Accomidation)].ToString();
                if(string.IsNullOrEmpty(accomodation))
                {
                    vm.PageNumber = 3;
                    var destination = TempData[nameof(Trip.Destination)].ToString();
                    vm.Trip = new Trip { Destination = destination };
                    return View("Add3", vm);
                }
                else
                {
                    vm.PageNumber = 2;
                    vm.Trip = new Trip { Accomidation = accomodation };
                    TempData.Keep(nameof(Trip.Accomidation));
                    return View("Add2", vm);
                }

            }else if(id == "Page3")
            {
                vm.PageNumber = 3;
                vm.Trip = new Trip { Destination = TempData.Peek(nameof(Trip.Destination)).ToString() };
                TempData.Keep(nameof(Trip.Accomidation));
                return View("Add3", vm);

            }
            else
            {

                vm.PageNumber = 1;
                return View("Add3", vm);

            }
        }
        [HttpPost]
        public IActionResult Add(TripViewModel vm)
        {
            if(vm.PageNumber == 1)
            {
                if(ModelState.IsValid)
                {
                    TempData[nameof(Trip.Destination)] = vm.Trip.Destination;
                    TempData[nameof(Trip.Accomidation)] = vm.Trip.Accomidation;
                    TempData[nameof(Trip.startDate)] = vm.Trip.startDate;
                    TempData[nameof(Trip.endDate)] = vm.Trip.endDate;
                    return RedirectToAction("Add", new { id = "Page2" });
                }
                else
                {
                    return View("Add1", vm);
                }
                
            }else if(vm.PageNumber == 2)
            {
                TempData[nameof(Trip.AccommodationPhone)] = vm.Trip.AccommodationPhone;
                TempData[nameof(Trip.AccommodationEmail)] = vm.Trip.AccommodationEmail;
                return RedirectToAction("Add", new { id = "Page3" });
            }
            else if(vm.PageNumber == 3)
            {
                vm.Trip.Destination = TempData[nameof(Trip.Destination)].ToString();
                vm.Trip.Accomidation = TempData[nameof(Trip.Accomidation)].ToString();
                vm.Trip.startDate = (DateTime)TempData[nameof(Trip.startDate)];
                vm.Trip.endDate = (DateTime)TempData[nameof(Trip.endDate)];
                vm.Trip.AccommodationPhone = TempData[nameof(Trip.AccommodationPhone)].ToString();
                vm.Trip.AccommodationEmail = TempData[nameof(Trip.AccommodationEmail)].ToString();

                context.Trips.Add(vm.Trip);
                context.SaveChanges();
                TempData["message"] = $"Trip to {vm.Trip.Destination} added";
                return RedirectToAction("Index","Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");

            }
        }
    }
}
