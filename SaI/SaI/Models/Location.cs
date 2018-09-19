using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SaI.Models
{
    public class Location
    {
        public int ID { get; set; }
        [DisplayName("Location Description")]
        public string Description { get; set; }
    }

    public class Locations
    {
        public List<Location> LocationList { get; set; }
    }
}