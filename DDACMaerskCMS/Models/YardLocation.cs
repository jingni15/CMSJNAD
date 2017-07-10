using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDACMaerskCMS.Models
{
    public class YardLocation
    {
        [Display(Name = "Yard ID")]
        public int YardLocationID { get; set; }

        [Required]
        [Display(Name = "Yard Name")]
        public String YardName { get; set; }

        [Required]
        [Display(Name = "Location")]
        public String LocationName { get; set; }

        [Required]
        [Display(Name = "Country")]
        public String CountryName { get; set; }
    }
}