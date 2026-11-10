using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VistaraAirlinesManagement.Models;

namespace VistaraAirlinesManagement.Controllers
{
    public class AdminController : Controller
    {
       AppDbContext db=new AppDbContext();
        // GET: Admin
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult AdminMenu()
        {
            return View();
        }
        public ActionResult AddFlight()
        {
            var data = Tuple.Create(new Flights(), new FlightStatus());
            return View(data);
        }

        [HttpPost]
        public ActionResult AddFlight(Flights Item1, FlightStatus Item2)
        {
            if (ModelState.IsValid)
            {
                Item2.Fcode = Item1.Fcode;

                db.Flights.Add(Item1);
                db.FlightsStatus.Add(Item2);

                db.SaveChanges();

                ViewBag.msg = "Flight Inserted Successfully";

                var data = Tuple.Create(new Flights(), new FlightStatus());

                return View(data);
            }

            ViewBag.msg = "Flight not Inserted";

            var model = Tuple.Create(Item1, Item2);

            return View(model);
        }
        public ActionResult ModifyFlight()
        {
            ViewBag.FlightCodes = new SelectList(
                     db.Flights.ToList(),"Fcode","Fcode");

            var flight = new Flights();
            var status = new FlightStatus();

            return View(Tuple.Create(flight, status));

        }

        [HttpPost]
        public ActionResult ModifyFlight(Flights Item1, FlightStatus Item2)
        {
            string id = Item1.Fcode;

            var flight = db.Flights.FirstOrDefault(x => x.Fcode == id);
            var fstatus = db.FlightsStatus.FirstOrDefault(x => x.Fcode == id);

            if (flight != null && fstatus != null)
            {
                flight.Fname = Item1.Fname;
                flight.Arrival = Item1.Arrival;
                flight.Source = Item1.Source;
                flight.Destination = Item1.Destination;
                flight.Departure = Item1.Departure;

                fstatus.Exe_Seats = Item2.Exe_Seats;
                fstatus.Exe_Fare = Item2.Exe_Fare;
                fstatus.Eco_Seats = Item2.Eco_Seats;
                fstatus.Eco_Fare = Item2.Eco_Fare;
                fstatus.Bus_Seats = Item2.Bus_Seats;
                fstatus.Bus_Fare = Item2.Bus_Fare;

                db.SaveChanges();

                ViewBag.status = "Flight Modified Successfully";
            }
            else
            {
                ViewBag.status = "Flight not found";
            }

            ViewBag.FlightCodes = new SelectList(
                db.Flights.ToList(),
                "Fcode",
                "Fcode",
                id
            );

            return View(Tuple.Create(flight ?? Item1, fstatus ?? Item2));
        }
        public JsonResult GetFlightDetails(string id)
        {
            var flight = db.Flights.FirstOrDefault(x => x.Fcode == id);

            var status = db.FlightsStatus.FirstOrDefault(x => x.Fcode == id);

            if (flight == null || status == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            var data = new
            {
                Source = flight.Source,
                Destination = flight.Destination,
                Arrival = flight.Arrival,
                Departure = flight.Departure,
                Fname = flight.Fname,

                Exe_Seats = status.Exe_Seats,
                Exe_Fare = status.Exe_Fare,
                Eco_Seats = status.Eco_Seats,
                Eco_Fare = status.Eco_Fare,
                Bus_Seats = status.Bus_Seats,
                Bus_Fare = status.Bus_Fare
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult DeleteFlight(string id)
        {
            
            var flight = db.Flights.FirstOrDefault(x => x.Fcode == id);
            var fstatus = db.FlightsStatus.FirstOrDefault(x => x.Fcode == id);

            var data = Tuple.Create(flight, fstatus);

            ViewBag.FlightCodes = new SelectList(
                db.Flights.ToList(),
                "Fcode",
                "Fcode",
                id
            );

            return View(data);
        }
        [HttpPost]
        public ActionResult DeleteFlightConfirmed(Flights Item1)
        {
            string id = Item1.Fcode;
            var fl = db.Flights.FirstOrDefault(x => x.Fcode == id);
            if (fl != null)
            {
                db.Flights.Remove(fl);
            }
            var fs = db.FlightsStatus.FirstOrDefault(x => x.Fcode == id);
            if (fs != null)
            {
                db.FlightsStatus.Remove(fs);
            }

            if (fl != null || fs != null)
            {
                db.SaveChanges();
                TempData["status"] = "Flight Deleted Successfully";
            }
            else
            {
                TempData["status"] = "Flight not found";
            }

            return RedirectToAction("DeleteFlight");
        }

    }
}