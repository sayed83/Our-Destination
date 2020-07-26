using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OurDestination.Models
{
    public class Customer
    {

        
        public Customer()
        {
            this.Orders = new HashSet<Orders>();
        }
        [Key]
        public System.Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string userid { get; set; }
        public int? comid { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

    }
}
