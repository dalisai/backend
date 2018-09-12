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
SELECT itemcode, 
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
                     ItemCode = DBHelper.GetString(rs, 0),
                     LongDescription = DBHelper.GetString(rs, 1),
                     ShortDescription = DBHelper.GetString(rs, 2),
                     DepartmentID = DBHelper.GetInt32(rs, 3), 
                     CategoryID = DBHelper.GetInt32(rs, 4),
                     SubCategoryID = DBHelper.GetInt32(rs, 5),
                     SupplierID = DBHelper.GetInt32(rs, 6),
                     LargePacking = DBHelper.GetString(rs, 7),
                     WithSerial = DBHelper.GetBoolean(rs, 8),
                     WithExpiry = DBHelper.GetBoolean(rs, 9),
                     IsVatable = DBHelper.GetBoolean(rs, 10),
                     IsInOpenDepartment = DBHelper.GetBoolean(rs, 11),
                     IsOpenPrice = DBHelper.GetBoolean(rs, 12)
                };
                items.Add(item);
            }
            return items;
        }
    }
}