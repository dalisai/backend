using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaI.Helpers;
using SaI.Models;
using SP = MySql.Data.MySqlClient.MySqlParameter;

namespace SaI.Repositories.MySql
{
    public class MySqlSupplierRepository
    {
        public List<Supplier> FindSuppliers() {
            var list = new List<Supplier>();
            string query = @"
SELECT id, 
    description 
FROM supplier";
            var rs = DBHelper.ExecuteReader(query, new SP());
            while (rs.Read()) {
                var item = new Supplier {
                    ID = DBHelper.GetInt32(rs, 0),
                    Description = DBHelper.GetString(rs, 1),
                   
                };
                list.Add(item);
            }
            return list;
        }

        public Supplier FindSupplier(int id) {
            string query = @"
SELECT id, 
    description 
FROM supplier
WHERE id = @ID";
            var rs = DBHelper.ExecuteReader(query, new SP("@ID", id));
            while (rs.Read()) {
                var item = new Supplier {
                    ID = DBHelper.GetInt32(rs, 0),
                    Description = DBHelper.GetString(rs, 1),
                };
                return item;
            }
            return null;
        }

        public Boolean SaveSupplier(Supplier supplier) {
            try {
                var query = string.Format(@"
INSERT INTO supplier(description) 
VALUES (@Description)");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@Description", supplier.Description));
                return true;
            }
            catch (Exception ex) { }
            return false;

        }

        public Boolean UpdateSupplier(Supplier supplier) {
            try {
                var query = string.Format(@"
UPDATE supplier 
SET Description = @Description
Where ID = @ID");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@Description", supplier.Description),
                    new SP("@ID", supplier.ID));
                return true;
            }
            catch (Exception ex) { }
            return false;
        }

        public Boolean RemoveSupplier(int id) {
            try {
                var query = string.Format(@"
DELETE FROM supplier 
Where ID = @ID");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@ID", id));
                return true;
            }
            catch (Exception ex) { }
            return false;
        }
    }
}