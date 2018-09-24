using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaI.Models
{
    public class ItemDetail
    {
        public int ID { get; set; }
        public int ItemDetailCode { get; set; }
        public int ItemDetailStockNo { get; set; }
        public int UnitID { get; set; }
        public string Packing { get; set; }
        public int Ratio { get; set; }
        public string Stock { get; set; }
        public int MaxInventory { get; set; }
        public int MinInventory { get; set; }
        public int BeginningQuantiy { get; set; }
        public DateTime PostDate { get; set; }
        public int ListCost { get; set; }
        public int NetCost { get; set; }
        public int MarkUp1 { get; set; }
        public int Price1 { get; set; }
        public int MarkUp2 { get; set; }
        public int Price2 { get; set; }
        public int MarkUp3 { get; set; }
        public int Price3 { get; set; }
        public int MarkUp4 { get; set; }
        public int Price4 { get; set; }
        public DateTime LastUpdate { get; set; }
        public Decimal DiscountPrice { get; set; }
        public Decimal DiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public string EndTime { get; set; }
        public DateTime LastDateSO { get; set; }
        public Boolean NotActive { get; set; }
        public Boolean XItem { get; set; }
        public Boolean OpenDepartment { get; set; }
        public string Remarks { get; set; }
    }

    public class ItemDetails
    {
        public List<ItemDetail> ItemDetailList { get; set; }
    }
}