using System;
using System.ComponentModel.DataAnnotations;

namespace OurDestination.Models
{
    public class Month
    {
        [Key]
        public int MonthId { get; set; }
        public string MonthName { get; set; }
    }
}
