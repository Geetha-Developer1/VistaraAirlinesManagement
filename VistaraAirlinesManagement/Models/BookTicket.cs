using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VistaraAirlinesManagement.Models
{
    public class BookTicket
    {
        public Bookings Booking { get; set; }

        public PassengerDetails Passenger { get; set; }

        public IEnumerable<SelectListItem> Flights { get; set; }
    }
}