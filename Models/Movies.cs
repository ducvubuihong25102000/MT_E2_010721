using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sang5_01_07.Models
{
    public class Movies
    {
        [Key]
        public string MovieId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Shows> Shows { get; set; }
    }
}