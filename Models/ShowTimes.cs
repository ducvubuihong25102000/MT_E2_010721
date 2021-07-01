using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sang5_01_07.Models
{
    public class ShowTimes
    {
        [Key]
        public string ShowTimeID { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        public ICollection<Shows> Shows { get; set; }
    }
}