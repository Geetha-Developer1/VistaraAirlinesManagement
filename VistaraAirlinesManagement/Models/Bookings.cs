using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VistaraAirlinesManagement.Models
{
    [Table("Bookings")]
    public class Bookings
    {
        [Key]
        public int BookingId {  get; set; }
        [Required]
        public string Fcode { get; set; }
        [Required]
        public DateTime FlyDate {  get; set; }
        [Required]
        public string Pass_Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string Seatno { get; set; }
        [Required]
        public decimal Fare { get; set; }

    }
}