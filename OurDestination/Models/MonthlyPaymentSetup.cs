using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OurDestination.Models
{
    public class MonthlyPaymentSetup
    {
        [Key]
        public int PaymentSetupId { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int? PaymentTypeId { get; set; }
        public virtual MemberPaymentType PaymentType { get; set; }
        public int? MonthId { get; set; }
        public virtual Month Month { get; set; }
        public decimal Total { get; set; }
        public int? Year { get; set; }
        public string userid { get; set; }
        public int? comid { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}