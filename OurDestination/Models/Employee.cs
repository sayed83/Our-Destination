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
        public string userid { get; set; }
        public int? comid { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
