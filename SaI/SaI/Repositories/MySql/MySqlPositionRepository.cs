using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaI.Helpers;
using SaI.Models;
using SP = MySql.Data.MySqlClient.MySqlParameter;

namespace SaI.Repositories.MySql
{
    public class MySqlPositionRepository
    {
        public List<Position> FindPositions() {
            var list = new List<Position>();
            string query = @"
SELECT id, 
       name 
FROM position";
            var rs = DBHelper.ExecuteReader(query, new SP());
            while (rs.Read()) {
                var item = new Position {
                    ID = DBHelper.GetInt32(rs, 0),
                    Name = DBHelper.GetString(rs, 1),
                   
                };
                list.Add(item);
            }
            rs.Close();
            return list;
        }

        public Position FindPosition(int id) {
            string query = @"
SELECT id, 
       name 
FROM position
WHERE id = @ID";
            var rs = DBHelper.ExecuteReader(query, new SP("@ID", id));
            while (rs.Read()) {
                var item = new Position {
                    ID = DBHelper.GetInt32(rs, 0),
                    Name = DBHelper.GetString(rs, 1),
                };
                rs.Close();
                return item;
            }
            rs.Close();
            return null;
        }

        public Boolean SavePosition(Position position) {
            try {
                var query = string.Format(@"
INSERT INTO position (name) 
VALUES (@Name)");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@Name", position.Name));
                return true;
            }
            catch (Exception ex) { }
            return false;

        }

        public Boolean UpdatePosition(Position position) {
            try {
                var query = string.Format(@"
UPDATE position 
SET Name = @Name
Where ID = @ID");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@Name", position.Name),
                    new SP("@ID", position.ID));
                return true;
            }
            catch (Exception ex) { }
            return false;
        }

        public Boolean RemovePosition(int id) {
            try {
                var query = string.Format(@"
DELETE FROM position 
Where ID = @ID");
                var rs = DBHelper.ExecuteNonQuery(query,
                    new SP("@ID", id));
                return true;
            }
            catch (Exception ex) { }
            return false;
        }

        public Boolean IsPositionExist(string name) {
            try {
                var query = string.Format(@"
Select * FROM position 
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