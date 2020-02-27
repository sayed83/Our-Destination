using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS_Rezor.Models
{
    public class ModuleGroup
    {
        [Key]
        public int ModuleGroupId { get; set; }
        public string ModuleGroupName { get; set; }
        public string ModuleGroupCaption { get; set; }
        public byte[] ModuleGroupImage { get; set; }
        public string ImagePath { get; set; }
        public string ImageExtension { get; set; }
        public int? SLNO { get; set; }

        public int ModuleId { get; set; }
        public virtual Modules Modules { get; set; }

        public virtual ICollection<ModuleMenu> ModuleMenu { get; set; }
    }
}