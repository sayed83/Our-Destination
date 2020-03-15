using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OurDestination.Models
{
    public class Orders
    {
        [Key]
        public System.Guid OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public System.Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        [NotMapped]
        public int Id { get; internal set; }
    }
}
