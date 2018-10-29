using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaI.Models
{
    public class Department
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter student name.")]
        public string Description { get; set; }
        public string BackColor { get; set; }
    }
}