using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaI.Models;
using SaI.Helpers;

namespace SaI.Repositories.Sql
{
    public class SqlItemRepository
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
FROM items";
            var rs = DBHelper.ExecuteReader(query, new MySql.Data.MySqlClient.MySqlParameter());
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
    }
}