using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDACMaerskCMS.Models
{
    public class ContainerShippingSchedule
    {
        [Display(Name = "Schedule ID")]
        public int ContainerShippingScheduleID { get; set; }

        [Required]
        [ForeignKey("Ship")]
        [Display(Name = "Ship Name")]
        public int ShipID { get; set; }
        public Ship Ship { get; set; }

        [Required]
        [ForeignKey("Container")]
        [Display(Name = "Container ID")]
        public int ContainerID { get; set; }
        public Container Container { get; set; }

        [Required]
        [ForeignKey("DepartureYardLocation")]
        [Display(Name = "Departure Shipyard")]
        public int DepartureShipyardID { get; set; }
        public virtual YardLocation DepartureYardLocation { get; set; }

        [Required]
        [ForeignKey("ArrivalYardLocation")]
        [Display(Name = "Arrival Shipyard")]
        public int ArrivalShipyardID { get; set; }
        public virtual YardLocation ArrivalYardLocation { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Departure Date Time")]
        public DateTime DepartureDateTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Arrival Date Time")]
        public DateTime ArrivalDateTime { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price Amount")]
        public Double PriceAmount { get; set; }
    }
}