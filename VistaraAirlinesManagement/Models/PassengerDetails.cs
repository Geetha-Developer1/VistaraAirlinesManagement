using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VistaraAirlinesManagement.Models
{
    [Table("PassengerDetails")]
    public class PassengerDetails
    {
        [Key]
        public int PassengerId {  get; set; }
      
        public string Fcode {  get; set; }
      
        public DateTime fdate { get; set; }
        
        public string name {  get; set; }
     
        public string address { get; set; }
    
        public string phno { get; set; }
        
        public string Email { get; set; }
        public string Amount { get; set; }
        public string Seatno { get; set; }
    }
}