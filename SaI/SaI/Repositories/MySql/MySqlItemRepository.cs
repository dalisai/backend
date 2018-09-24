using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaI.Models;
using SaI.Helpers;
using MySql.Data.MySqlClient;
using SP = MySql.Data.MySqlClient.MySqlParameter;

namespace SaI.Repositories.MySql
{
    public class MySqlItemRepository
    {
        public List<Item> FindItems()
        {
            var items = new List<Item>();
            string query = @"
SELECT id, 
    itemcode, 
    longdescription, 
    shortdescription, 
    departmentid, 
    categoryid, 
    subcategoryid, 
    supplierid, 
    largepacking, 
    withserial, 
    withexpiry, 
    vatable, 
    isOpenDept, 
    isOpenPrice 
FROM items 
ORDER BY id";
            var rs = DBHelper.ExecuteReader(query);
            while (rs.Read()) {
                var item = new Item {
                    ID = DBHelper.GetInt32(rs, 0),
                    ItemCode = DBHelper.GetString(rs, 1),
                    LongDescription = DBHelper.GetString(rs, 2),
                    ShortDescription = DBHelper.GetString(rs, 3),
                    DepartmentID = DBHelper.GetInt32(rs, 4), 
                    CategoryID = DBHelper.GetInt32(rs, 5),
                    SubCategoryID = DBHelper.GetInt32(rs, 6),
                    SupplierID = DBHelper.GetInt32(rs, 7),
                    LargePacking = DBHelper.GetString(rs, 8),
                    WithSerial = DBHelper.GetBoolean(rs, 9),
                    WithExpiry = DBHelper.GetBoolean(rs, 10),
                    IsVatable = DBHelper.GetBoolean(rs, 11),
                    IsInOpenDepartment = DBHelper.GetBoolean(rs, 12),
                    IsOpenPrice = DBHelper.GetBoolean(rs, 13)
                };
                items.Add(item);
            }
            return items;
        }

        public Item GetItem(int id)
        {
            string query = @"
SELECT id, 
    itemcode, 
    longdescription, 
    shortdescription, 
    departmentid, 
    categoryid, 
    subcategoryid, 
    supplierid, 
    largepacking, 
    withserial, 
    withexpiry, 
    vatable, 
    isOpenDept, 
    isOpenPrice 
FROM items 
WHERE id = @ID";

            var rs = DBHelper.ExecuteReader(query, new SP("@ID", id));
            while (rs.Read()) {
                var item = new Item {
                    ID = DBHelper.GetInt32(rs, 0),
                    ItemCode = DBHelper.GetString(rs, 1),
                    LongDescription = DBHelper.GetString(rs, 2),
                    ShortDescription = DBHelper.GetString(rs, 3),
                    DepartmentID = DBHelper.GetInt32(rs, 4),
                    CategoryID = DBHelper.GetInt32(rs, 5),
                    SubCategoryID = DBHelper.GetInt32(rs, 6),
                    SupplierID = DBHelper.GetInt32(rs, 7),
                    LargePacking = DBHelper.GetString(rs, 8),
                    WithSerial = DBHelper.GetBoolean(rs, 9),
                    WithExpiry = DBHelper.GetBoolean(rs, 10),
                    IsVatable = DBHelper.GetBoolean(rs, 11),
                    IsInOpenDepartment = DBHelper.GetBoolean(rs, 12),
                    IsOpenPrice = DBHelper.GetBoolean(rs, 13)
                };
                return item;
            }
            return null;
        }

        public int SaveItem(Item item)
        {
            Random rnd = new Random();
            string query = @"
INSERT INTO Items (itemcode, longdescription, shortdescription, departmentid, categoryid, subcategoryid, supplierid, largepacking, withserial, withexpiry, vatable, isOpenDept, isOpenPrice) 
VALUES (@ItemCode, @LongDescription, @ShortDescription, @DepartmentID, @CategoryID, @SubCategoryID, @SupplierID, @LargePacking, @WithSerial, @WithExpiry, @Vatable, @IsOpenDept, @IsOpenPrice); 
SELECT LAST_INSERT_ID()";
            int x = DBHelper.ExecuteScalar<int>(query,
                new SP("@ItemCode", Convert.ToInt32(rnd.Next(0, 1000))),
                new SP("@LongDescription", item.LongDescription),
                new SP("@ShortDescription", item.ShortDescription),
                new SP("@DepartmentID", item.DepartmentID),
                new SP("@CategoryID", item.CategoryID),
                new SP("@SubCategoryID", item.SubCategoryID),
                new SP("@SupplierID", item.SupplierID),
                new SP("@LargePacking", item.LargePacking),
                (item.WithSerial ? new SP("@WithSerial", 1) : new SP("@WithSerial", System.DBNull.Value)),
                (item.WithExpiry ? new SP("@WithExpiry", 1) : new SP("@WithExpiry", System.DBNull.Value)),
                (item.IsVatable ? new SP("@Vatable", 1) : new SP("@Vatable", System.DBNull.Value)),
                (item.IsInOpenDepartment ? new SP("@IsOpenDept", 1) : new SP("@IsOpenDept", System.DBNull.Value)),
                (item.IsOpenPrice ? new SP("@IsOpenPrice", 1) : new SP("@IsOpenPrice", System.DBNull.Value)));
            return x;
        }

        public Boolean UpdateItem(Item item)
        {
            string query = @"
UPDATE Items SET longdescription = @LongDescription, 
    shortdescription = @ShortDescription, 
    departmentid = @DepartmentID, 
    categoryid = @CategoryID, 
    subcategoryid = @SubCategoryID, 
    supplierid = @SupplierID, 
    largepacking = @LargePacking, 
    withserial = @WithSerial, 
    withexpiry = @WithExpiry, 
    vatable = @Vatable, 
    isOpenDept = @IsOpenDept, 
    isOpenPrice = @IsOpenPrice 
WHERE id = @ID";
            DBHelper.ExecuteNonQuery(query,
                new SP("@ID", item.ID), 
                new SP("@LongDescription", item.LongDescription),
                new SP("@ShortDescription", item.ShortDescription),
                new SP("@DepartmentID", item.DepartmentID),
                new SP("@CategoryID", item.CategoryID),
                new SP("@SubCategoryID", item.SubCategoryID),
                new SP("@SupplierID", item.SupplierID),
                new SP("@LargePacking", item.LargePacking),
                (item.WithSerial ? new SP("@WithSerial", 1) : new SP("@WithSerial", System.DBNull.Value)),
                (item.WithExpiry ? new SP("@WithExpiry", 1) : new SP("@WithExpiry", System.DBNull.Value)),
                (item.IsVatable ? new SP("@Vatable", 1) : new SP("@Vatable", System.DBNull.Value)),
                (item.IsInOpenDepartment ? new SP("@IsOpenDept", 1) : new SP("@IsOpenDept", System.DBNull.Value)),
                (item.IsOpenPrice ? new SP("@IsOpenPrice", 1) : new SP("@IsOpenPrice", System.DBNull.Value)));

            return true;
        }

        public List<ItemDetail> FindItemDetails(Item item)
        {
            var itemDetails = new List<ItemDetail>();
            string query = @"
SELECT id, 
    stockno, 
	unitid, 
    packing, 
    ratio, 
    stock, 
    max_inventory, 
    min_inventory, 
    beg_quantity 
FROM item_details 
WHERE itemcode = @ItemCode";
            var rs = DBHelper.ExecuteReader(query, new SP("@ItemCode", item.ItemCode));
            while (rs.Read()) {
                var itemDetail = new ItemDetail {
                    ID = DBHelper.GetInt32(rs, 0),
                    ItemDetailStockNo = DBHelper.GetInt32(rs, 1),
                    UnitID = DBHelper.GetInt32(rs, 2),
                    Packing = DBHelper.GetString(rs, 3),
                    Ratio = DBHelper.GetInt32(rs, 4),
                    Stock = DBHelper.GetString(rs, 5),
                    MaxInventory = DBHelper.GetInt32(rs, 6),
                    MinInventory = DBHelper.GetInt32(rs, 7),
                    BeginningQuantiy = DBHelper.GetInt32(rs, 8)
                };
                itemDetails.Add(itemDetail);
            }
            return itemDetails;
        }

        public ItemDetail GetItemDetails(int detailID)
        {
            string query = @"
SELECT id, 
    stockno, 
	unitid, 
    packing, 
    ratio, 
    stock, 
    max_inventory, 
    min_inventory, 
    beg_quantity, 
    postdate, 
    listcost, 
    netcost, 
    markup1, 
    price1, 
    markup2, 
    price2, 
    markup3, 
    price3, 
    markup4, 
    price4, 
    lastupdate, 
    discountp, 
    discounta, 
    sdate, 
    stime, 
    edate, 
    etime, 
    lastdateso, 
    notactive, 
    xitem, 
    opendept, 
    remarks 
FROM item_details 
WHERE id = @ID";
            var rs = DBHelper.ExecuteReader(query, new SP("@ID", detailID));
            while (rs.Read()) {
                var itemDetailData = new ItemDetail {
                    ID = DBHelper.GetInt32(rs, 0),
                    ItemDetailStockNo = DBHelper.GetInt32(rs, 1),
                    UnitID = DBHelper.GetInt32(rs, 2),
                    Packing = DBHelper.GetString(rs, 3),
                    Ratio = DBHelper.GetInt32(rs, 4),
                    Stock = DBHelper.GetString(rs, 5),
                    MaxInventory = DBHelper.GetInt32(rs, 6),
                    MinInventory = DBHelper.GetInt32(rs, 7),
                    BeginningQuantiy = DBHelper.GetInt32(rs, 8),
                    PostDate = DBHelper.GetDateTime(rs, 9),
                    ListCost = DBHelper.GetInt32(rs, 10),
                    NetCost = DBHelper.GetInt32(rs, 11),
                    MarkUp1 = DBHelper.GetInt32(rs, 12),
                    Price1 = DBHelper.GetInt32(rs, 13),
                    MarkUp2 = DBHelper.GetInt32(rs, 14),
                    Price2 = DBHelper.GetInt32(rs, 15),
                    MarkUp3 = DBHelper.GetInt32(rs, 15),
                    Price3 = DBHelper.GetInt32(rs, 17),
                    MarkUp4 = DBHelper.GetInt32(rs, 18),
                    Price4 = DBHelper.GetInt32(rs, 19),
                    LastUpdate = DBHelper.GetDateTime(rs, 20),
                    DiscountPrice = DBHelper.GetDecimal(rs, 21),
                    DiscountAmount = DBHelper.GetDecimal(rs, 22),
                    StartDate = DBHelper.GetDateTime(rs, 23),
                    StartTime = DBHelper.GetString(rs, 24),
                    EndDate = DBHelper.GetDateTime(rs, 25),
                    EndTime = DBHelper.GetString(rs, 26),
                    LastDateSO = DBHelper.GetDateTime(rs, 27),
                    NotActive = DBHelper.GetBoolean(rs, 28),
                    XItem = DBHelper.GetBoolean(rs, 29),
                    OpenDepartment = DBHelper.GetBoolean(rs, 30),
                    Remarks = DBHelper.GetString(rs, 31)
                };
                return itemDetailData;
            }
            return null;
        }

        public int SaveDetail(ItemDetail itemDetail)
        {
            string query = @"
INSERT INTO item_details (itemcode, stockno, unitid, packing, ratio, stock, max_inventory, min_inventory, beg_quantity, postdate, listcost, netcost, markup1, price1, markup2, price2, markup3, price3, markup4, price4, lastupdate, discountp, discounta, sdate, stime, edate, etime, lastdateso, notactive, xitem, opendept, remarks) 
VALUES (@ItemCode, @StockNo, @UnitID, @Packing, @Ratio, @Stock, @MaxInventory, @MinInventory, @BegQuantity, @Postdate, @Listcost, @Netcost, @Markup1, @Price1, @Markup2, @Price2, @Markup3, @Price3, @Markup4, @Price4, NOW(), @Discountp, @Discounta, @Sdate, @Stime, @Edate, @Etime, @Lastdateso, @Notactive, @Xitem, @Opendept, @Remarks)";

            int x = DBHelper.ExecuteNonQuery(query,
                new SP("@ItemCode", itemDetail.ItemDetailCode),
                new SP("@StockNo", itemDetail.ItemDetailStockNo),
                new SP("@UnitID", itemDetail.UnitID),
                new SP("@Packing", itemDetail.Packing),
                new SP("@Ratio", itemDetail.Ratio),
                new SP("@Stock", itemDetail.Stock),
                new SP("@MaxInventory", itemDetail.MaxInventory),
                new SP("@MinInventory", itemDetail.MinInventory),
                new SP("@BegQuantity", itemDetail.BeginningQuantiy),
                new SP("@Postdate", itemDetail.PostDate),
                new SP("@Listcost", itemDetail.ListCost),
                new SP("@Netcost", itemDetail.NetCost),
                new SP("@Markup1", itemDetail.MarkUp1),
                new SP("@Price1", itemDetail.Price1),
                new SP("@Markup2", itemDetail.MarkUp2),
                new SP("@Price2", itemDetail.Price2),
                new SP("@Markup3", itemDetail.MarkUp3),
                new SP("@Price3", itemDetail.Price3),
                new SP("@Markup4", itemDetail.MarkUp4),
                new SP("@Price4", itemDetail.Price4),
                new SP("@Discountp", itemDetail.DiscountPrice),
                new SP("@Discounta", itemDetail.DiscountAmount),
                new SP("@Sdate", itemDetail.StartDate),
                new SP("@Stime", itemDetail.StartTime),
                new SP("@Edate", itemDetail.EndDate),
                new SP("@Etime", itemDetail.EndTime),
                new SP("@Lastdateso", itemDetail.LastDateSO),
                (itemDetail.NotActive ? new SP("@Notactive", 1) : new SP("@Notactive", System.DBNull.Value)),
                (itemDetail.XItem ? new SP("@Xitem", 1) : new SP("@Xitem", System.DBNull.Value)),
                (itemDetail.OpenDepartment ? new SP("@Opendept", 1) : new SP("@Opendept", System.DBNull.Value)),
                new SP("@Remarks", itemDetail.Remarks));
            return x;
        }

        public int UpdateDetail(ItemDetail itemDetail)
        {
            string query = @"
UPDATE item_details SET itemcode = @ItemCode, 
    stockno = @StockNo, 
    unitid = @UnitID, 
    packing = @Packing, 
    ratio = @Ratio, 
    stock = @Stock, 
    max_inventory = @MaxInventory, 
    min_inventory = @MinInventory, 
    beg_quantity = @BegQuantity, 
    postdate = @Postdate, 
    listcost = @Listcost, 
    netcost = @Netcost, 
    markup1 = @Markup1, 
    price1 = @Price1, 
    markup2 = @Markup2, 
    price2 = @Price2, 
    markup3 = @Markup3, 
    price3 = @Price3, 
    markup4 = @Markup4, 
    price4 = @Price4, 
    lastupdate = NOW(), 
    discountp = @Discountp, 
    discounta = @Discounta, 
    sdate = @Sdate, 
    stime = @Stime, 
    edate = @Edate, 
    etime = @Etime, 
    lastdateso = @Lastdateso, 
    notactive = @Notactive, 
    xitem = @Xitem, 
    opendept = @Opendept, 
    remarks = @Remarks 
WHERE id = @ID";

            int x = DBHelper.ExecuteNonQuery(query,
                new SP("@ID", itemDetail.ID), 
                new SP("@ItemCode", itemDetail.ItemDetailCode),
                new SP("@StockNo", itemDetail.ItemDetailStockNo),
                new SP("@UnitID", itemDetail.UnitID),
                new SP("@Packing", itemDetail.Packing),
                new SP("@Ratio", itemDetail.Ratio),
                new SP("@Stock", itemDetail.Stock),
                new SP("@MaxInventory", itemDetail.MaxInventory),
                new SP("@MinInventory", itemDetail.MinInventory),
                new SP("@BegQuantity", itemDetail.BeginningQuantiy),
                new SP("@Postdate", itemDetail.PostDate),
                new SP("@Listcost", itemDetail.ListCost),
                new SP("@Netcost", itemDetail.NetCost),
                new SP("@Markup1", itemDetail.MarkUp1),
                new SP("@Price1", itemDetail.Price1),
                new SP("@Markup2", itemDetail.MarkUp2),
                new SP("@Price2", itemDetail.Price2),
                new SP("@Markup3", itemDetail.MarkUp3),
                new SP("@Price3", itemDetail.Price3),
                new SP("@Markup4", itemDetail.MarkUp4),
                new SP("@Price4", itemDetail.Price4),
                new SP("@Discountp", itemDetail.DiscountPrice),
                new SP("@Discounta", itemDetail.DiscountAmount),
                new SP("@Sdate", itemDetail.StartDate),
                new SP("@Stime", itemDetail.StartTime),
                new SP("@Edate", itemDetail.EndDate),
                new SP("@Etime", itemDetail.EndTime),
                new SP("@Lastdateso", itemDetail.LastDateSO),
                (itemDetail.NotActive ? new SP("@Notactive", 1) : new SP("@Notactive", System.DBNull.Value)),
                (itemDetail.XItem ? new SP("@Xitem", 1) : new SP("@Xitem", System.DBNull.Value)),
                (itemDetail.OpenDepartment ? new SP("@Opendept", 1) : new SP("@Opendept", System.DBNull.Value)),
                new SP("@Remarks", itemDetail.Remarks));
            return x;
        }

        public int RemoveItem(int id)
        {
            string query = @"
DELETE i, itemD
FROM items i
INNER JOIN item_details itemD
  ON i.itemcode = itemD.itemcode 
WHERE i.id = @ID";
            int x = DBHelper.ExecuteNonQuery(query, new SP("@ID", id));
            return x;
        }

        public int RemoveDetail(int id)
        {
            string query = @"
DELETE FROM item_details 
WHERE id = @ID";
            int x = DBHelper.ExecuteNonQuery(query, new SP("@ID", id));
            return x;
        }

    }
}