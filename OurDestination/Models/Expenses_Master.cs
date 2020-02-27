using System;
using System.ComponentModel.DataAnnotations;

namespace POS_Rezor.Models
{
    public class Expenses_Master
    {
        [Key]
        public int ExpenceMasterId { get; set; }
        [Required]
        public string ExpensesName { get; set; }
        public float ExpensesAmnount { get; set; }
        public DateTime? ExpensesDate { get; set; }

        public string ExpensesDec { get; set; }
        public int? userid { get; set; }
        public int? comid { get; set; }
        public DateTime? EntryDate { get; set; }
        public string AddedBy { get; set; }
        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }

    }

}
