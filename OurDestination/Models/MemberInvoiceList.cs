using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OurDestination.Models
{
    public class MemberInvoiceList
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<decimal> DueAmount { get; set; }
        public int? MemberId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> MonthlyPaymentSetupId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<int> MonthId { get; set; }
        public Nullable<decimal> PreviousDue { get; set; }

        public virtual Member Member { get; set; }
        public virtual Month Month { get; set; }
        public virtual MonthlyPaymentSetup MonthlyPaymentSetup { get; set; }
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