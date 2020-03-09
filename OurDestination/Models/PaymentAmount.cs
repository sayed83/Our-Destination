using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OurDestination.Models
{
    public class PaymentAmount
    {
        [Key]
        public int PaymentAmountId { get; set; }
        public int? PaymentTypeId { get; set; }
        public virtual MemberPaymentType MemberPaymentType { get; set; }
        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int? MonthId { get; set; }
        public virtual Month Month { get; set; }
        public Decimal? Amount { get; set; }
        public bool Active { get; set; }
        public int? userid { get; set; }
        public int? comid { get; set; }
    }
}