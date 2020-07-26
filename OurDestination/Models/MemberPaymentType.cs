using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OurDestination.Models
{
    public class MemberPaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }
        [Required]
        public string PaymentType { get; set; }
        public string PaymentAmount { get; set; }
        public bool Active { get; set; }
        public string userid { get; set; }
        public int? comid { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}