using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaI.Helpers;
using SaI.Models;
using SP = MySql.Data.MySqlClient.MySqlParameter;

namespace SaI.Repositories.MySql
{
    public class MySqlDiscountRepository
    {
        public List<Discount> FindDiscounts()
        {
            var list = new List<Discount>();
            string query = @"
SELECT id, 
    discount_type, 
    percent
FROM discount_type";
            var rs = DBHelper.ExecuteReader(query, new SP());
            while (rs.Read())
            {
                var item = new Discount
                {
                    ID = DBHelper.GetInt32(rs, 0),
                    DiscountType = DBHelper.GetString(rs, 1),
                    Percent = DBHelper.GetInt32(rs, 2)
                };
                list.Add(item);
            }
            return list;
        }

        public Discount FindDiscount(int id)
        {
            string query = @"
SELECT id, 
    discount_type, 
    percent
FROM discount_type
WHERE id = @ID";
            var rs = DBHelper.ExecuteReader(query, new SP("@ID", id));
            while (rs.Read())
            {
                var item = new Discount
                {
                    ID = DBHelper.GetInt32(rs, 0),
                    DiscountType = DBHelper.GetString(rs, 1),
                    Percent = DBHelper.GetInt32(rs, 2)
                };
                return item;
            }
            return null;
        }

        public Boolean SaveDiscount(Discount discount)
        {

            try
            {
                var query = string.Format(@"
INSERT INTO DISCOUNT_TYPE(discount_type, percent) 
VALUES (@DiscountType, @Percent)");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@DiscountType", discount.DiscountType),
                    new SP("@Percent", discount.Percent));

                return true;
            }
            catch (Exception ex) { }
            return false;

        }

        public Boolean UpdateDiscount(Discount discount)
        {
            try
            {
                var query = string.Format(@"
UPDATE Discount_type 
SET discount_type = @DiscountType, percent = @Percent
Where ID = @ID");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@DiscountType", discount.DiscountType),
                    new SP("@Percent", discount.Percent),
                    new SP("@ID", discount.ID));

                return true;
            }
            catch (Exception ex) { }
            return false;
        }

        public Boolean RemoveDiscount(int id)
        {


            try
            {
                var query = string.Format(@"
DELETE FROM Discount_type 
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