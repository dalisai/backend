using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaI.Models
{
    public class Category
    {
        public int ID { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }
    }
}