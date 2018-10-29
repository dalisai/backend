using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SaI.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string ItemCode { get; set; }
        [Required]
        public string LongDescription { get; set; }
        [Required]
        [StringLength(20)]
        public string ShortDescription { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public int SubCategoryID { get; set; }
        [Required]
        public int SupplierID { get; set; }
        [Required]
        public string LargePacking { get; set; }
        public bool IsVatable { get; set; }
        public bool IsOpenPrice { get; set; }
        public bool IsInOpenDepartment { get; set; }
        public bool WithSerial { get; set; }
        public bool WithExpiry { get; set; }
    }

    public class Items
    {
        public List<Item> ItemList { get; set; }
    }
}