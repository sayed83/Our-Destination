using OurDestination.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurDestination.Models
{
    public class DeptHeadCount
    {
        public Dept Department { get; set; }
        public int Count { get; set; }
        public string userid { get; set; }
        public int? comid { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
