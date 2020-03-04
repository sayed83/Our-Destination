using System;
using System.ComponentModel.DataAnnotations;

namespace OurDestination.Models
{

    public class Expenses_Details
    {
        [Key]
        public int ExpenceDetailsId { get; set; }
        public string ExpenceDescription { get; set; }
        public int? userid { get; set; }
        public int? comid { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}",ApplyFormatInEditMode =true)]
        public DateTime? EntryDate { get; set; }
        public string AddedBy { get; set; }
        public int? ExpenceMasterId { get; set; }
        public virtual Expenses_Master Expenses_Master { get; set; }
    }
}
