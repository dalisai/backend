using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaI.Models
{
    public class Position
    {

        public int ID { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }
    }
}