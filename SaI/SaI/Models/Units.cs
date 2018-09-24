using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SaI.Models
{
    public class Unit
    {
        public int ID { get; set; }
        [DisplayName("Unit Name")]
        public string Description { get; set; }
    }

    public class Units
    {
        public List<Unit> UnitList { get; set; }
    }
}