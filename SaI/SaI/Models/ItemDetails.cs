using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SaI.Models
{
    public class ItemDetail
    {
        public int ID { get; set; }
        public int ItemDetailCode { get; set; }
        [Required]
        public int ItemDetailStockNo { get; set; }
        [Required]
        public int UnitID { get; set; }
        [Required]
        public string Packing { get; set; }
        [Required]
        public int Ratio { get; set; }
        [Required]
        public string Stock { get; set; }
        [Required]
        public int MaxInventory { get; set; }
        [Required]
        public int MinInventory { get; set; }
        [Required]
        public int BeginningQuantiy { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public Decimal ListCost { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public Decimal NetCost { get; set; }
        [Required]
        public int MarkUp1 { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public Decimal Price1 { get; set; }
        [Required]
        public int MarkUp2 { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public Decimal Price2 { get; set; }
        [Required]
        public int MarkUp3 { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public Decimal Price3 { get; set; }
        [Required]
        public int MarkUp4 { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public Decimal Price4 { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime LastUpdate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public Decimal DiscountPrice { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public Decimal DiscountAmount { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public string StartTime { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public string EndTime { get; set; }
        [Required]
        [DataType(DataType.Date)]
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