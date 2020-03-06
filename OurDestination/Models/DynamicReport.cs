using System;
using System.ComponentModel.DataAnnotations;

namespace OurDestination.Models
{
    public class DynamicReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DynamicReportId { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Dynamic Report Name")]
        public string DynamicReportName { get; set; }
        public string DynamicReportCaption { get; set; }
        public string DynamicReportActionName { get; set; }
        public string ReportDesignByPerson { get; set; }
        public string ReportLocation { get; set; }
        public string ReportController { get; set; }
        public string VerifiedByPerson { get; set; }
        public bool isVerified { get; set; }
        public decimal CompletePercentage { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }


        public Nullable<int> comid { get; set; }

        [StringLength(128)]
        public string userid { get; set; }

        [StringLength(128)]
        public string useridupdate { get; set; }
    }
}
