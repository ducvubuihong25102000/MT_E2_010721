using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sang5_01_07.Models
{
    public class Cinemas
    {
        [Key]
        public string CinemaId { get; set; }
        [Required]
        public string CinemaName { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public ICollection<Shows> Shows { get; set; }
    }
}