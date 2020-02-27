using System;
using System.ComponentModel.DataAnnotations;

namespace POS_Rezor.Models
{
    public class MenuPermission_Details
    {
        [Key]
        public int MenuPermissionDetailsId { get; set; }
        public bool IsCreated { get; set; }
        public bool IsUpdated { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsView { get; set; }
        public bool IsReport { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public int MenuPermissionMasterId { get; set; }
        public virtual MenuPermission_Master MenuPermission_Master { get; set; }
        public int ModuleMenuId { get; set; }
        public virtual ModuleMenu ModuleMenu { get; set; }

    }
}