using System;
using System.ComponentModel.DataAnnotations;

namespace OurDestination.Models
{
    public class Profession
    {
        public int ProfessionId { get; set; }
        public string ProfessionName { get; set; }
        public int? userid { get; set; }
        public int? comid { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? AddedDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedDate { get; set; }
    }
}