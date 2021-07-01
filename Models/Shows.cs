using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sang5_01_07.Models
{
    public class Shows
    {
        [Key]
        public string ShowId { get; set; }
        [ForeignKey("Cinemas")]
        public string CinemaId { get; set; }
        public Cinemas Cinemas { get; set; }

        [ForeignKey("ShowDays")]
        public string ShowDayId { get; set; }
        public ShowDays ShowDays { get; set; }

        [ForeignKey("Movies")]
        public string MovieId { get; set; }
        public Movies Movies { get; set; }

        [ForeignKey("ShowTimes")]
        public string ShowTimeId{ get; set; }
        public ShowTimes ShowTimes { get; set; }

        public ICollection<Reservations> Reservations { get; set; }

    }
}