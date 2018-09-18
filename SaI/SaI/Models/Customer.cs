using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaI.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Input customer name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Input credit limit")]
        public double  CreditLimit { get; set; }
        [Required(ErrorMessage = "Input discount")]
        public int Discount { get; set; }
        public double PriceType { get; set; }
        [Required(ErrorMessage = "Input birthday")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Input address")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required(ErrorMessage = "Input telephone number")]
        public string Telephone{ get; set; }
        [Required(ErrorMessage = "Input fax number")]
        public string Fax { get; set; }
        public DateTime DateAdded { get; set; }
        public string Type { get; set; }
        public string Remarks { get; set; }
        public string Company { get; set; }
        public int Points { get; set; }
        public DateTime LastVisit { get; set; }
        public string Photo { get; set; }
}
}