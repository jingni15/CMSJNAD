using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDACMaerskCMS.Models
{
    public class Ship
    {
        [Display(Name = "Ship ID")]
        public int ShipID { get; set; }

        [Required]
        [Display(Name = "Ship Name")]
        public String ShipName { get; set; }

        [Display(Name = "Ship Type")]
        public String ShipType { get; set; }

        [Required]
        [Display(Name = "Ship Weight")]
        public int ShipWeight { get; set; }

        [Required]
        [Display(Name = "Total Containers")]
        public int TotalContainers { get; set; }
    }
}