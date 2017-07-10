using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDACMaerskCMS.Models
{
    public class Container
    {
        [Display(Name = "Container ID")]
        public int ContainerID { get; set; }

        [Required]
        [Display(Name = "Container Description")]
        public String ContainerDescription { get; set; }

        [Required]
        [Display(Name = "Container Weight")]
        public int ContainerWeight { get; set; }
    }
}