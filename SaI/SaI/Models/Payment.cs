using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SaI.Models
{
    public class Payment
    {
        public int ID { get; set; }
        [DisplayName("Payment Name")]
        public string Description { get; set; }
        [DisplayName("Ratio")]
        public decimal Ratio { get; set; }
    }

    public class Payments
    {
        public List<Payment> PaymentList { get; set; }
    }
}