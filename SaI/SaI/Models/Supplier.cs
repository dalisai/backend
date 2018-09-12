using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaI.Models
{
    public class Supplier
    {

        [NotMapped]
        public int SupplierID { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }
 

     
    }
}