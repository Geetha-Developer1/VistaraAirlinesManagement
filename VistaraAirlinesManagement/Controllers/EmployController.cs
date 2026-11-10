using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VistaraAirlinesManagement.Models;

namespace VistaraAirlinesManagement.Controllers
{
    public class EmployController : Controller
    {
        AppDbContext db=new AppDbContext();
        // GET: Employ
        public ActionResult EmployeeHome()
        {
            return View();
        }
        public ActionResult EmployeeMenu()
        {
            return View();
        }
        public ActionResult ShowFlights()
        {
            List<Flights> flights = db.Flights.ToList();

            List<FlightStatus> flightStatus = db.FlightsStatus.ToList();

            var data = Tuple.Create(flights, flightStatus);

            return View(data);
        }
        public ActionResult BookTicket()
        {
            var model = new BookTicket
            {
                Booking = new Bookings(),
                Passenger = new PassengerDetails(),

                Flights = db.Flights.Select(x => new SelectListItem
                {
                    Value = x.Fcode,
                    Text = x.Fname
                }).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult BookTicket(BookTicket model)
        {
            if (ModelState.IsValid)
            {
                Bookings bk = new Bookings();

                bk.Fcode = model.Booking.Fcode;
                bk.FlyDate = model.Booking.FlyDate;
                bk.Pass_Name = model.Booking.Pass_Name;
                bk.Address = model.Booking.Address;
                bk.Phone = model.Booking.Phone;
                bk.Class = model.Booking.Class;
                bk.Seatno = model.Booking.Seatno;
                bk.Fare = model.Booking.Fare;

                db.Bookings.Add(bk);

                PassengerDetails psd = new PassengerDetails();

                psd.Fcode = model.Booking.Fcode;
                psd.fdate = model.Booking.FlyDate;
                psd.name = model.Booking.Pass_Name;
                psd.address = model.Booking.Address;
                psd.phno = model.Booking.Phone;
                psd.Email = model.Passenger.Email;
                psd.Amount = model.Passenger.Amount;
                psd.Seatno = model.Booking.Seatno;

                db.PassengerDetails.Add(psd);

                db.SaveChanges();

                ViewBag.book = "Successfully Ticket Booking is Done";
            }
            else
            {
                ViewBag.book = "Ticket is not Booked";
            }

            model.Flights = db.Flights.Select(x => new SelectListItem
            {
                Value = x.Fcode,
                Text = x.Fname
            }).ToList();

            return View(model);
        }
        public ActionResult CancelTicket()
        {
            ViewBag.bkid = new SelectList(
                db.Bookings.ToList(),
                "BookingId",
                "BookingId"
            );

            var model = Tuple.Create(
                new Bookings(),
                new PassengerDetails()
            );

            return View(model);
        }
        public ActionResult GetBookingDetails(int id)
        {
            var booking = db.Bookings
                            .FirstOrDefault(x => x.BookingId == id);

            if (booking == null)
                return Json(null, JsonRequestBehavior.AllowGet);

            var passenger = db.PassengerDetails
                              .FirstOrDefault(x => x.Fcode == booking.Fcode);

            if (passenger == null)
                return Json(null, JsonRequestBehavior.AllowGet);

            var data = new
            {
                booking.Fcode,
                FlyDate = booking.FlyDate.ToString("yyyy-MM-dd"),
                booking.Pass_Name,
                booking.Address,
                booking.Phone,
                booking.Class,
                booking.Seatno,
                booking.Fare,
                passenger.Email,
                passenger.Amount
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CancelTicket(int BookingId, DateTime Canceldate)
        {
            var bk = db.Bookings.FirstOrDefault(
                x => x.BookingId == BookingId
            );

            if (bk == null)
            {
                TempData["can"] = "Booking not found";
                return RedirectToAction("CancelTicket");
            }

            var pass = db.PassengerDetails.FirstOrDefault(
                x => x.Fcode == bk.Fcode
            );

            if (pass == null)
            {
                TempData["can"] = "Passenger not found";
                return RedirectToAction("CancelTicket");
            }

            bool check = db.cancels.Any(
                x => x.BookingId == BookingId
            );

            if (check)
            {
                TempData["can"] = "Ticket already cancelled";
                return RedirectToAction("CancelTicket");
            }

            decimal red = Convert.ToDecimal(pass.Amount) * 0.15m;
            decimal bal = Convert.ToDecimal(pass.Amount) - red;

            Cancels cn = new Cancels()
            {
                BookingId = BookingId,
                Fcode = bk.Fcode,
                Canceldate = Canceldate,
                Flightdate = bk.FlyDate,
                Pass_Name = bk.Pass_Name,
                address = bk.Address,
                phone = bk.Phone,
                classtype = bk.Class,
                Seatno = bk.Seatno,
                Amount = Convert.ToDecimal(pass.Amount),
                fare = bk.Fare,
                Reduction = red,
                ReturnBal = bal
            };

            db.cancels.Add(cn);
            db.SaveChanges();

            TempData["can"] = "Ticket Cancelled Successfully";

            return RedirectToAction("CancelTicket");
        }
    }
}