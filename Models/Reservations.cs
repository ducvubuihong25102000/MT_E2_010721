using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sang5_01_07.Models
{
    public class Reservations
    {
        [Key]
        public string ReservationId { get; set; }

        [ForeignKey("Shows")]
        public string ShowId{ get; set; }
        public Shows Shows { get; set; }

        [ForeignKey("Seats")]
        public string SeatId { get; set; }
        public Seats Seats { get; set; }

        public ApplicationUser Customer { get; set; }

    }
}