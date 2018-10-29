using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaI.Models
{
    public class Discount
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Input discount type")]
        public string DiscountType { get; set; }
        [Required(ErrorMessage ="Input discount percentage")]
        public int Percent { get; set; }
    }
}