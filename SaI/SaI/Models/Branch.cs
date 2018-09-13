using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SaI.Models
{
    public class Branch
    {
        public int ID { get; set; }
        [DisplayName("Branch Name")]
        public string Description { get; set; }
    }

    public class Branches
    {
        public List<Branch> BranchList { get; set; }
    }
}