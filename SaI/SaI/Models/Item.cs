using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaI.Models
{
    public class Item
    {
        public string ItemCode { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public int DepartmentID { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public int SupplierID { get; set; }
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