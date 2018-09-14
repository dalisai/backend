using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaI.Helpers;
using SaI.Models;
using SP = MySql.Data.MySqlClient.MySqlParameter;

namespace SaI.Repositories.MySql
{
    public class MySqlCategoryRepository
    {
        public List<Category> FindCategories() {
            var list = new List<Category>();
            string query = @"
SELECT id, 
    description 
FROM category";
            var rs = DBHelper.ExecuteReader(query, new SP());
            while (rs.Read()) {
                var item = new Category {
                    ID = DBHelper.GetInt32(rs, 0),
                    Description = DBHelper.GetString(rs, 1),
                   
                };
                list.Add(item);
            }
            return list;
        }

        public Category FindCategory(int id) {
            string query = @"
SELECT id, 
    description 
FROM category
WHERE id = @ID";
            var rs = DBHelper.ExecuteReader(query, new SP("@ID", id));
            while (rs.Read()) {
                var item = new Category {
                    ID = DBHelper.GetInt32(rs, 0),
                    Description = DBHelper.GetString(rs, 1),
                };
                return item;
            }
            return null;
        }

        public Boolean SaveCategory(Category category) {
            try {
                var query = string.Format(@"
INSERT INTO category(description) 
VALUES (@Description)");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@Description", category.Description));
                return true;
            }
            catch (Exception ex) { }
            return false;

        }

        public Boolean UpdateCategory(Category category) {
            try {
                var query = string.Format(@"
UPDATE category 
SET Description = @Description
Where ID = @ID");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@Description", category.Description),
                    new SP("@ID", category.ID));
                return true;
            }
            catch (Exception ex) { }
            return false;
        }

        public Boolean RemoveCategory(int id) {
            try {
                var query = string.Format(@"
DELETE FROM category 
Where ID = @ID");
                var rs = DBHelper.ExecuteNonQuery(query,
                    new SP("@ID", id));
                return true;
            }
            catch (Exception ex) { }
            return false;
        }

        public Boolean IsCategoryExist(string description) {
            try {
                var query = string.Format(@"
Select * FROM category 
Where description = @description");
                var rs = DBHelper.ExecuteReader(query, 
                            new SP("@description", description));
                 if(rs.Read()) {
                    return true;
                 }
            }
            catch (Exception ex) { }
            return false;
        }
    }
}