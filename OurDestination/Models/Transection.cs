using System;
using System.ComponentModel.DataAnnotations;

namespace POS_Rezor.Models
{
    public class Transection
    {

        public int TransectionId { get; set; }
        [Required]
        public Month Month { get; set; }
        [Required]
        public DateTime GivenDate { get; set; }
        public DateTime? EntryDate { get; set; }

        [Required]
        public float TransectionAmount { get; set; }
        public int? userid { get; set; }
        public int? comid { get; set; }
        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }

    }

    public enum Month
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
}
