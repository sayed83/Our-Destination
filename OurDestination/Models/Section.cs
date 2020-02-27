using System;
using System.ComponentModel.DataAnnotations;

namespace POS_Rezor.Models
{
    public class Section
    {
        
        public int SectionId { get; set; }
        [Required]
        public string SectionName { get; set; }

    }
}
