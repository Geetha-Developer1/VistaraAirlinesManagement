using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VistaraAirlinesManagement.Models
{
    [Table("Flights")]
    public class Flights
    {
       [Key]
        public string Fcode {  get; set; }
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Source {  get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string Arrival {  get; set; }
        [Required]
        public string Departure {  get; set; }
    }
}