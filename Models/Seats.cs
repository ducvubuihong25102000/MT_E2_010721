using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sang5_01_07.Models
{
    public class Seats
    {
        [Key]
        public string SeatID { get; set; }
        [Required]
        public int SeatNo { get; set; }
        public bool Status { get; set; }
        [Required]
        public double Price { get; set; }

        public ICollection<Reservations> Reservations { get; set; }

    }
}