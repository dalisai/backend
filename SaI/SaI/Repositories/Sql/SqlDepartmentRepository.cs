using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaI.Helpers;
using SaI.Models;
using SP = MySql.Data.MySqlClient.MySqlParameter;

namespace SaI.Repositories.Sql
{
    public class SqlDepartmentRepository
    {
        public List<Department> FindDepartments()
        {
            var list = new List<Department>();
            string query = @"
SELECT id, 
    description, 
    backcolor
FROM dept";
            var rs = DBHelper.ExecuteReader(query, new SP());
            while (rs.Read()) {
                var item = new Department {
                     ID = DBHelper.GetInt32(rs, 0),
                     Description = DBHelper.GetString(rs, 1),
                     BackColor = DBHelper.GetString(rs, 2)
                };
                list.Add(item);
            }
            return list;
        }

        public Department FindDepartment(int id)
        {
            string query = @"
SELECT id, 
    description, 
    backcolor
FROM dept
WHERE id = @ID";
            var rs = DBHelper.ExecuteReader(query, new SP("@ID", id));
            while (rs.Read())
            {
                var item = new Department
                {
                    ID = DBHelper.GetInt32(rs, 0),
                    Description = DBHelper.GetString(rs, 1),
                    BackColor = DBHelper.GetString(rs, 2)
                };
                return item;
            }
            return null;
        }

        public Boolean SaveDepartment(Department department) {

            try {
                var query = string.Format(@"
INSERT INTO DEPT(description, backcolor) 
VALUES (@Description, @BackColor)");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@Description", department.Description),
                    new SP("@BackColor", department.BackColor));

                return true;
            }
            catch (Exception ex) { }
            return false;
            
        }

        public Boolean UpdateDepartment(Department department) {
            try
            {
                var query = string.Format(@"
UPDATE Dept 
SET Description = @Description, BackColor = @BackColor
Where ID = @ID");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@Description", department.Description),
                    new SP("@BackColor", department.BackColor),
                    new SP("@ID", department.ID));

                return true;
            }
            catch (Exception ex) { }
            return false;
        }
    }
}