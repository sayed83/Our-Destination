using System;
using System.ComponentModel.DataAnnotations;

namespace POS_Rezor.Models
{
    public class ReportVM
    {
        public int ReportId { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string PaymentTypeId { get; set; }
        public decimal MontlyFee { get; set; }
        public decimal HalfYearlyFee { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal Dueamount { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Total { get; set; }
        public string remarks { get; set; }
    }
}
