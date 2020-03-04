using System;
using System.ComponentModel.DataAnnotations;

namespace OurDestination.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
