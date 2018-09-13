﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaI.Models
{
    public class SubCategory
    {
        [NotMapped]
        public int SubCategoryID { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }
    }
}