using System;
using System.ComponentModel.DataAnnotations;

namespace OurDestination.Models
{
    public class Transection
    {

        public int TransectionId { get; set; }
        [Required]
        public int MonthId { get; set; }
        public virtual Month Month { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime GivenDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EntryDate { get; set; }

        [Required]
        public float TransectionAmount { get; set; }
        public int? userid { get; set; }
        public int? comid { get; set; }
        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }

    }

    
}
