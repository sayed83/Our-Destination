using System;
using System.ComponentModel.DataAnnotations;

namespace OurDestination.Models
{
    public class Invest
    {
        [Key]
        public int InvestId { get; set; }
        [Required]
        public string InvestPurpose { get; set; }
        [Required]
        public float InvestAmount { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InvestDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExpireDate { get; set; }
        public int? userid { get; set; }
        public int? comid { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EntryDate { get; set; }
        public string AddedBy { get; set; }
        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }
        public string UpdatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? AddedDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedDate { get; set; }
    }
}
