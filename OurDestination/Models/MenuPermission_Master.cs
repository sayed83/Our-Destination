using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS_Rezor.Models
{
    public class MenuPermission_Master
    {
        [Key]
        public int MenuPermissionMasterId { get; set; }
        public string useridPermission { get; set; }
        public int comid { get; set; }
        public string userid { get; set; }
        public string useridUpdate { get; set; }
        public bool Active { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }

        public virtual ICollection<MenuPermission_Details> MenuPermission_Details { get; set; }
    }
}