using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VistaraAirlinesManagement.Models
{
    [Table("FlightStatus")]
    public class FlightStatus
    {
        [Key]
        [ForeignKey("Flights")]
        public string Fcode {  get; set; }
        [Required]
        public int Exe_Seats {  get; set; }
        [Required]
        public decimal Exe_Fare {  get; set; }
        [Required]
        public int Eco_Seats { get; set; }
        [Required]
        public decimal Eco_Fare { get; set; }
        [Required]
        public int Bus_Seats { get; set; }
        [Required]
        public decimal Bus_Fare { get;set; }
        
        public virtual Flights Flights { get; set; }

    }
}