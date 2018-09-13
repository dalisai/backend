using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaI.Models;
using SaI.Helpers;
using SP = MySql.Data.MySqlClient.MySqlParameter;

namespace SaI.Repositories.MySql
{
    public class MySqlBranchRepository
    {
        public List<Branch> FindBranch()
        {
            var branches = new List<Branch>();
            string query = @"
SELECT ID, 
    Description 
FROM branch";
            var rs = DBHelper.ExecuteReader(query);
            while (rs.Read()) {
                var branch = new Branch {
                    ID = DBHelper.GetInt32(rs, 0),
                    Description = DBHelper.GetString(rs, 1)
                };
                branches.Add(branch);
            }
            return branches;
        }

        public Branch GetBranch(int id)
        {
            Branch branchData = new Branch();
            string query = @"
SELECT ID, 
    Description 
FROM branch 
WHERE id = @ID";
            var rs = DBHelper.ExecuteReader(query, new SP("@ID", id));
            while (rs.Read()) {
                branchData = new Branch {
                    ID = DBHelper.GetInt32(rs, 0),
                    Description = DBHelper.GetString(rs, 1)
                };
            }
            return branchData;
        }

        public bool SaveBranch(string description)
        {
            string query = @"
INSERT INTO branch (Description) 
VALUES (@Description)";
            DBHelper.ExecuteNonQuery(query, new SP("@Description", description));
            return true;
        }

        public bool UpdateBranch(int id, string description)
        {
            string query = @"
UPDATE branch SET Description = @Description 
WHERE id = @ID";
            DBHelper.ExecuteNonQuery(query, new SP("@Description", description), new SP("@ID", id));
            return true;
        }

        public bool RemoveBranch(int? id)
        {
            string query = @"
DELETE FROM branch 
WHERE id = @ID";
            DBHelper.ExecuteNonQuery(query, new SP("@ID", id));
            return true;
        }
    }
}