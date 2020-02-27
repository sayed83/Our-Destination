using System;
using System.ComponentModel.DataAnnotations;

namespace POS_Rezor.Models
{
    public class Invest
    {
        [Key]
        public int InvestId { get; set; }
        [Required]
        public string InvestPurpose { get; set; }
        [Required]
        public float InvestAmount { get; set; }
        public DateTime InvestDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int? userid { get; set; }
        public int? comid { get; set; }
        public DateTime? EntryDate { get; set; }
        public string AddedBy { get; set; }
        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }
    }
}
