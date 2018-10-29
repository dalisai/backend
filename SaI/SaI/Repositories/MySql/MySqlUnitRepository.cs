using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaI.Models;
using SaI.Helpers;
using SP = MySql.Data.MySqlClient.MySqlParameter;

namespace SaI.Repositories.MySql
{
    public class MySqlUnitRepository
    {
        public List<Unit> FindUnits()
        {
            var units = new List<Unit>();
            string query = @"
SELECT ID, 
    Description 
FROM unit";
            var rs = DBHelper.ExecuteReader(query);
            while (rs.Read()) {
                var unit = new Unit {
                    ID = DBHelper.GetInt32(rs, 0),
                    Description = DBHelper.GetString(rs, 1)
                };
                units.Add(unit);
            }
            rs.Close();
            return units;
        }

        public Unit GetUnit(int id)
        {
            Unit unitData = new Unit();
            string query = @"
SELECT ID, 
    Description 
FROM unit 
WHERE id = @ID";
            var rs = DBHelper.ExecuteReader(query, new SP("@ID", id));
            while (rs.Read()) {
                unitData = new Unit {
                    ID = DBHelper.GetInt32(rs, 0),
                    Description = DBHelper.GetString(rs, 1)
                };
            }
            rs.Close();
            return unitData;
        }

        public bool SaveUnit(string description)
        {
            string query = @"
INSERT INTO unit (Description) 
VALUES (@Description)";
            DBHelper.ExecuteNonQuery(query, new SP("@Description", description));
            return true;
        }

        public bool UpdateUnit(int id, string description)
        {
            string query = @"
UPDATE unit SET Description = @Description 
WHERE id = @ID";
            DBHelper.ExecuteNonQuery(query, new SP("@Description", description), new SP("@ID", id));
            return true;
        }

        public bool RemoveUnit(int? id)
        {
            string query = @"
DELETE FROM unit 
WHERE id = @ID";
            DBHelper.ExecuteNonQuery(query, new SP("@ID", id));
            return true;
        }
    }
}