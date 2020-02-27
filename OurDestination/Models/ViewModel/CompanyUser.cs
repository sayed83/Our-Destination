using System;
using System.ComponentModel.DataAnnotations;

namespace POS_Rezor.Models
{
    public class CompanyUser
    {
        public int ComId { get; set; }

        public string CompanyName { get; set; }

        public int isDefault { get; set; }


    }
}
