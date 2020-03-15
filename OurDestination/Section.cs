using System;
using System.ComponentModel.DataAnnotations;

namespace OurDestination.Models
{
    public class Section
    {
        
        public int SectionId { get; set; }
        [Required]
        public string SectionName { get; set; }

    }
}
