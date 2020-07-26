using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OurDestination.Models
{
    public class Modules
    {
        [Key]
        public int ModuleId { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public string ModuleCaption { get; set; }
        public string ModuleDescription { get; set; }
        public string ModuleLink { get; set; }
        public byte[] ModuleImage { get; set; }
        public string ModuleImagePath { get; set; }
        public string ModuleImageExtension { get; set; }
        public int IsInActive { get; set; }
        public int? SLNO { get; set; }

        public virtual ICollection<ModuleGroup> ModuleGroups { get; set; }
    }
}
