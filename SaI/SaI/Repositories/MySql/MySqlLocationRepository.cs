using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaI.Models;
using SaI.Helpers;
using SP = MySql.Data.MySqlClient.MySqlParameter;

namespace SaI.Repositories.MySql
{
    public class MySqlLocationRepository
    {
        public List<Location> FindLocation()
        {
            var purposes = new List<Location>();
            string query = @"
SELECT ID, 
    Description 
FROM location";
            var rs = DBHelper.ExecuteReader(query);
            while (rs.Read()) {
                var purpose = new Location {
                    ID = DBHelper.GetInt32(rs, 0),
                    Description = DBHelper.GetString(rs, 1)
                };
                purposes.Add(purpose);
            }
            rs.Close();
            return purposes;
        }

        public Location GetLocation(int id)
        {
            Location purposeData = new Location();
            string query = @"
SELECT ID, 
    Description 
FROM location 
WHERE id = @ID";
            var rs = DBHelper.ExecuteReader(query, new SP("@ID", id));
            while (rs.Read()) {
                purposeData = new Location {
                    ID = DBHelper.GetInt32(rs, 0),
                    Description = DBHelper.GetString(rs, 1)
                };
            }
            rs.Close();
            return purposeData;
        }

        public bool SaveLocation(string description)
        {
            string query = @"
INSERT INTO location (Description) 
VALUES (@Description)";
            DBHelper.ExecuteNonQuery(query, new SP("@Description", description));
            return true;
        }

        public bool UpdateLocation(int id, string description)
        {
            string query = @"
UPDATE location SET Description = @Description 
WHERE id = @ID";
            DBHelper.ExecuteNonQuery(query, new SP("@Description", description), new SP("@ID", id));
            return true;
        }

        public bool RemoveLocation(int? id)
        {
            string query = @"
DELETE FROM location 
WHERE id = @ID";
            DBHelper.ExecuteNonQuery(query, new SP("@ID", id));
            return true;
        }
    }
}