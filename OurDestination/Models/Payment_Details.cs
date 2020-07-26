using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OurDestination.Models
{
    public class Payment_Details
    {
        [Key]
        public int PaymentDetailsId { get; set; }
        public int? PaymentTypeId { get; set; }
        public virtual MemberPaymentType MemberPaymentType { get; set; }
        public int? MonthId { get; set; }
        public virtual Month Month { get; set; }
        public DateTime? PaymentDate { get; set; }
        public Decimal? PaymentAmount { get; set; }
        public Decimal? TotalAmount { get; set; }
        public Decimal? NetAmount { get; set; }
        public DateTime? GivenYear { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? userid { get; set; }
        public int? comid { get; set; }
        public int PaymentMasterId { get; set; }
        public virtual Payment_Master Payment_Master { get; set; }
    }
}