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
        public int PaymentId { get; set; }
        [Required]
        public string PaymentType { get; set; }
        public bool Active { get; set; }
    }
}