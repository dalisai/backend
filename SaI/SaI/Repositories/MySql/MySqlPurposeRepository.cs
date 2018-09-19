using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaI.Models;
using SaI.Helpers;
using SP = MySql.Data.MySqlClient.MySqlParameter;

namespace SaI.Repositories.MySql
{
    public class MySqlPurposeRepository
    {
        public List<Purpose> FindPurpose()
        {
            var purposes = new List<Purpose>();
            string query = @"
SELECT ID, 
    Description 
FROM purpose";
            var rs = DBHelper.ExecuteReader(query);
            while (rs.Read()) {
                var purpose = new Purpose {
                    ID = DBHelper.GetInt32(rs, 0),
                    Description = DBHelper.GetString(rs, 1)
                };
                purposes.Add(purpose);
            }
            return purposes;
        }

        public Purpose GetPurpose(int id)
        {
            Purpose purposeData = new Purpose();
            string query = @"
SELECT ID, 
    Description 
FROM purpose 
WHERE id = @ID";
            var rs = DBHelper.ExecuteReader(query, new SP("@ID", id));
            while (rs.Read()) {
                purposeData = new Purpose {
                    ID = DBHelper.GetInt32(rs, 0),
                    Description = DBHelper.GetString(rs, 1)
                };
            }
            return purposeData;
        }

        public bool SavePurpose(string description)
        {
            string query = @"
INSERT INTO purpose (Description) 
VALUES (@Description)";
            DBHelper.ExecuteNonQuery(query, new SP("@Description", description));
            return true;
        }

        public bool UpdatePurpose(int id, string description)
        {
            string query = @"
UPDATE purpose SET Description = @Description 
WHERE id = @ID";
            DBHelper.ExecuteNonQuery(query, new SP("@Description", description), new SP("@ID", id));
            return true;
        }

        public bool RemovePurpose(int? id)
        {
            string query = @"
DELETE FROM purpose 
WHERE id = @ID";
            DBHelper.ExecuteNonQuery(query, new SP("@ID", id));
            return true;
        }
    }
}