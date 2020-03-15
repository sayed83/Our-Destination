using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OurDestination.Models
{
    public class Payment_Master
    {
        [Key]
        public int PaymentMasterId { get; set; }
        public int? PaymentTypeId { get; set; }
        public virtual MemberPaymentType MemberPaymentType { get; set; }
        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int? MonthId { get; set; }
        public virtual Month Month { get; set; }
        public DateTime? PaymentDate { get; set; }
        public Decimal? Amount { get; set; }
        public DateTime? GivenYear { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool Active { get; set; }
        public int? userid { get; set; }
        public int? comid { get; set; }

    }
}