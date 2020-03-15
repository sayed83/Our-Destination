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

        
        public virtual ICollection<Orders> Orders { get; set; }

    }
}
