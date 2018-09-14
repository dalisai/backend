using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaI.Helpers;
using SaI.Models;
using SP = MySql.Data.MySqlClient.MySqlParameter;

namespace SaI.Repositories.MySql
{
    public class MySqlSubCategoryRepository
    {
        public List<SubCategory> FindSubCategories() {
            var list = new List<SubCategory>();
            string query = @"
SELECT id, 
    description 
FROM subcategory";
            var rs = DBHelper.ExecuteReader(query, new SP());
            while (rs.Read()) {
                var item = new SubCategory {
                    ID = DBHelper.GetInt32(rs, 0),
                    Description = DBHelper.GetString(rs, 1),
                };
                list.Add(item);
            }
            return list;
        }

        public SubCategory FindSubCategory(int id) {
            string query = @"
SELECT id, 
    description
FROM subcategory
WHERE id = @ID";
            var rs = DBHelper.ExecuteReader(query, new SP("@ID", id));
            while (rs.Read()) {
                var item = new SubCategory {
                    ID = DBHelper.GetInt32(rs, 0),
                    Description = DBHelper.GetString(rs, 1),
                };
                return item;
            }
            return null;
        }

        public Boolean SaveSubCategory(SubCategory subcategory) {
            try {
                var query = string.Format(@"
INSERT INTO subcategory(description) 
VALUES (@Description)");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@Description", subcategory.Description));
                return true;
            }
            catch (Exception ex) { }
            return false;

        }

        public Boolean UpdateSubCategory(SubCategory subcategory) {
            try {
                var query = string.Format(@"
UPDATE subcategory 
SET Description = @Description
Where ID = @ID");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@Description", subcategory.Description),
                    new SP("@ID", subcategory.ID));
                return true;
            }
            catch (Exception ex) { }
            return false;
        }

        public Boolean RemoveSubCategory(int id) {
            try {
                var query = string.Format(@"
DELETE FROM subcategory 
Where ID = @ID");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@ID", id));
                return true;
            }
            catch (Exception ex) { }
            return false;
        }
        public Boolean IsSubCategoryExist(string description) {
            try {
                var query = string.Format(@"
Select * FROM subcategory 
Where description = @description");
                var rs = DBHelper.ExecuteReader(query,
                            new SP("@description", description));
                if (rs.Read()) {
                    return true;
                }
            }
            catch (Exception ex) { }
            return false;
        }
    }
}