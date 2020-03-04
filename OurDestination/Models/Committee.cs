using System;
using System.ComponentModel.DataAnnotations;

namespace OurDestination.Models
{
    public class Committee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Position { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ElactedDate { get; set; }
        public int? userid { get; set; }
        public int? comid { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EntryDate { get; set; }
        public string AddedBy { get; set; }
        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }

    }
}
