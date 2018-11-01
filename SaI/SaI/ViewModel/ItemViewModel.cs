using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaI.Models;

namespace SaI.ViewModel
{
    public class ItemViewModel
    {
        public List<Department> DepartmentList { get; set; }
        public List<Supplier> SupplierList { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<SubCategory> SubCategoryList { get; set; }
        public List<Unit> UnitList { get; set; }
        public Item Item { get; set; }
        public List<ItemDetail> ItemDetailList { get; set; }
        public ItemDetail ItemDetail { get; set; }
        public List<Position> PositionList { get; set; }
    }
}