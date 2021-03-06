using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sang5_01_07.Models
{
    public class ShowDays
    {
        [Key]
        public string ShowDayID { get; set; }
        [Required]
        public DataType Day { get; set; }
        public ICollection<Shows> Shows { get; set; }
    }
}