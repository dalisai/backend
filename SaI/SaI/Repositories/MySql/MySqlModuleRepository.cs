using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaI.Helpers;
using SaI.Models;
using SP = MySql.Data.MySqlClient.MySqlParameter;

namespace SaI.Repositories.MySql
{
    public class MySqlModuleRepository
    {
        public List<Module> FindModules() {
            var list = new List<Module>();
            string query = @"
SELECT id, 
       name 
FROM module";
            var rs = DBHelper.ExecuteReader(query, new SP());
            while (rs.Read()) {
                var item = new Module {
                    ID = DBHelper.GetInt32(rs, 0),
                    Name = DBHelper.GetString(rs, 1),
                   
                };
                list.Add(item);
            }
            rs.Close();
            return list;
        }

        public Module FindModule(int id) {
            string query = @"
SELECT id, 
       name 
FROM module
WHERE id = @ID";
            var rs = DBHelper.ExecuteReader(query, new SP("@ID", id));
            while (rs.Read()) {
                var item = new Module {
                    ID = DBHelper.GetInt32(rs, 0),
                    Name = DBHelper.GetString(rs, 1),
                };
                rs.Close();
                return item;
            }
            rs.Close();
            return null;
        }

        public Boolean SaveModule(Module module) {
            try {
                var query = string.Format(@"
INSERT INTO module (name) 
VALUES (@Name)");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@Name", module.Name));
                return true;
            }
            catch (Exception ex) { }
            return false;

        }

        public Boolean UpdateModule(Module module) {
            try {
                var query = string.Format(@"
UPDATE module 
SET Name = @Name
Where ID = @ID");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@Name", module.Name),
                    new SP("@ID", module.ID));
                return true;
            }
            catch (Exception ex) { }
            return false;
        }

        public Boolean RemoveModule(int id) {
            try {
                var query = string.Format(@"
DELETE FROM module 
Where ID = @ID");
                var rs = DBHelper.ExecuteNonQuery(query,
                    new SP("@ID", id));
                return true;
            }
            catch (Exception ex) { }
            return false;
        }

        public Boolean IsModuleExist(string name) {
            try {
                var query = string.Format(@"
Select * FROM module 
Where name = @name");
                var rs = DBHelper.ExecuteReader(query, 
                            new SP("@name", name));
                 if(rs.Read()) {
                    return true;
                 }
            }
            catch (Exception ex) { }
            return false;
        }
    }
}