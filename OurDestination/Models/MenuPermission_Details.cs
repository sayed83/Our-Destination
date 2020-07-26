using OurDestination.Models;
using POS_Rezor.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace OurDestination.Models
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
        public int? userid { get; set; }
        public int? comid { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? AddedDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedDate { get; set; }

    }
}