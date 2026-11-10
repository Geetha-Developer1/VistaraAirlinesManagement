using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VistaraAirlinesManagement.Models
{
    [Table("ManagerLogin")]
    public class ManagerLogin
    {
        [Key]
        public int Mid {  get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
       
    }
}