using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SaI.Models
{
    public class Purpose
    {
        public int ID { get; set; }
        [DisplayName("Purpose Name")]
        public string Description { get; set; }
    }

    public class Purposes
    {
        public List<Purpose> PurposeList { get; set; }
    }
}