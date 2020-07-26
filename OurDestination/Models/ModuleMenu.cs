using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OurDestination.Models
{
    public class ModuleMenu
    {
        [Key]
        public int ModuleMenuId { get; set; }
        public string ModuleMenuName { get; set; }
        public string ModuleMenuCaption { get; set; }
        public byte[] ModuleMenuImage { get; set; }
        public string ImagePath { get; set; }
        public string ModuleImageExtension { get; set; }
        public string ModuleMenuController { get; set; }
        public string ModuleMenuLink { get; set; }
        public int IsInActive { get; set; }
        public string IsParent { get; set; }
        public bool Active { get; set; }
        public int? SLNO { get; set; }


        public int ModuleId { get; set; }
        public virtual Modules Modules { get; set; }
        public int ModuleGroupId { get; set; }
        public virtual ModuleGroup ModuleGroup { get; set; }
         public int ImageCriteriaId { get; set; }
        public virtual ImageCriteria ImageCriteria { get; set; }

        [ForeignKey("ModuleMenuId")]
        public int ParentId { get; set; }
        public virtual ModuleMenu ParentModuleMenu { get; set; }
        public virtual ICollection<ModuleMenu> ModuleMenuChildren { get; set; }

    }
}