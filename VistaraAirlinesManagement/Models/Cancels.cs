using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VistaraAirlinesManagement.Models
{
    [Table("cancels")]
    public class Cancels
    {
        [Key]
        public int cancelId { get; set; }
        [Required]
        public string Fcode {  get; set; }
        [Required]
        public DateTime Canceldate {  get; set; }
        [Required]
        public DateTime Flightdate {  get; set; }
        [Required]
        public string Pass_Name {  get; set; }
        [Required]
        public string address {  get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        [Column("class")]
        public string classtype { get; set; }
        [Required]
        public string Seatno { get; set; }
       [Required]
       public decimal Amount { get; set; }
        [Required]
        public decimal fare { get; set; }
        [Required]
        public decimal Reduction { get; set; }
        [Required]
        public decimal ReturnBal { get; set; }
        [ForeignKey("Booking")]
        public int BookingId { get; set; }

        public Bookings Booking { get; set; }
    }
}