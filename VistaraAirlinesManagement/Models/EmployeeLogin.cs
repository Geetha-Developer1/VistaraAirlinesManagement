using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VistaraAirlinesManagement.Models
{
    [Table("EmployeeLogin")]
    public class EmployeeLogin
    {
        [Key]
        public int Eid {  get; set; }
        [Required]
        public string Username {  get; set; }
        [Required]
        public string Password { get; set; }
       
    }
}