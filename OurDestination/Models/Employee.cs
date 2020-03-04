using System;
using System.ComponentModel.DataAnnotations;

namespace OurDestination.Models
{
    public class Employee
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public int? SectionId { get; set; }
        public virtual Section Section { get; set; }
    }
}
