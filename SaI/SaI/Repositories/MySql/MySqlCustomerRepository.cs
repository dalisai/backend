using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaI.Helpers;
using SaI.Models;
using SP = MySql.Data.MySqlClient.MySqlParameter;

namespace SaI.Repositories.MySql
{
    public class MySqlCustomerRepository
    {
        public List<Customer> FindCustomers()
        {
            var list = new List<Customer>();
            string query = @"
SELECT id, 
    customer_name, 
    credit_limit,
    discount,
    price_type,
    birthday,
    address1,
    address2,
    tel_no,
    fax_no,
    date,
    type,
    remarks,
    company,
    points,
    last_visit,
    photo
FROM Customer";
            var rs = DBHelper.ExecuteReader(query, new SP());
            while (rs.Read())
            {
                var item = new Customer
                {
                    ID = DBHelper.GetInt32(rs, 0),
                    Name = DBHelper.GetString(rs, 1),
                    CreditLimit = DBHelper.GetInt32(rs, 2),
                    Discount = DBHelper.GetInt32(rs, 3),
                    PriceType = DBHelper.GetInt32(rs, 4),
                    Birthday = DBHelper.GetDateTime(rs, 5),
                    Address1 = DBHelper.GetString(rs, 6),
                    Address2 = DBHelper.GetString(rs, 7),
                    Telephone = DBHelper.GetString(rs, 8),
                    Fax = DBHelper.GetString(rs, 9),
                    DateAdded = DBHelper.GetDateTime(rs, 10),
                    Type = DBHelper.GetString(rs, 11),
                    Remarks = DBHelper.GetString(rs, 12),
                    Company = DBHelper.GetString(rs, 13),
                    Points = DBHelper.GetInt32(rs, 14),
                    LastVisit = DBHelper.GetDateTime(rs, 15),
                    Photo = DBHelper.GetString(rs, 16)
                };
                list.Add(item);
            }
            return list;
        }

        public Customer FindCustomer(int id)
        {
            string query = @"
SELECT id, 
    customer_name, 
    credit_limit,
    discount,
    price_type,
    birthday,
    address1,
    address2,
    tel_no,
    fax_no,
    date,
    type,
    remarks,
    company,
    points,
    last_visit,
    photo
FROM Customer
WHERE id = @ID";
            var rs = DBHelper.ExecuteReader(query, new SP("@ID", id));
            while (rs.Read())
            {
                var item = new Customer
                {
                    ID = DBHelper.GetInt32(rs, 0),
                    Name = DBHelper.GetString(rs, 1),
                    CreditLimit = DBHelper.GetInt32(rs, 2),
                    Discount = DBHelper.GetInt32(rs, 3),
                    PriceType = DBHelper.GetInt32(rs, 4),
                    Birthday = DBHelper.GetDateTime(rs, 5),
                    Address1 = DBHelper.GetString(rs, 6),
                    Address2 = DBHelper.GetString(rs, 7),
                    Telephone = DBHelper.GetString(rs, 8),
                    Fax = DBHelper.GetString(rs, 9),
                    DateAdded = DBHelper.GetDateTime(rs, 10),
                    Type = DBHelper.GetString(rs, 11),
                    Remarks = DBHelper.GetString(rs, 12),
                    Company = DBHelper.GetString(rs, 13),
                    Points = DBHelper.GetInt32(rs, 14),
                    LastVisit = DBHelper.GetDateTime(rs, 15),
                    Photo = DBHelper.GetString(rs, 16)
                };
                return item;
            }
            return null;
        }

        public Boolean SaveCustomer(Customer customer)
        {

            try
            {
                var query = string.Format(@"
INSERT INTO Customer(customer_name, credit_limit, discount, price_type, birthday, address1, address2, tel_no, fax_no, date, type, remarks, company, points, last_visit, photo) 
VALUES (@CustomerName, @CreditLimit, @Discount, @PriceType, @Birthday, @Address1, @Address2, @Telephone, @Fax, @DateAdded, @Type, @Remarks, @Company, @Points, @LastVisit, @Photo)");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@CustomerName", customer.Name),
                    new SP("@CreditLimit", customer.CreditLimit),
                    new SP("@Discount", customer.Discount),
                    new SP("@PriceType", customer.PriceType),
                    new SP("@Birthday", customer.Birthday),
                    new SP("@Address1", customer.Address1),
                    new SP("@Address2", customer.Address2),
                    new SP("@Telephone", customer.Telephone),
                    new SP("@Fax", customer.Fax),
                    new SP("@DateAdded", customer.DateAdded),
                    new SP("@Type", customer.Type),
                    new SP("@Remarks", customer.Remarks),
                    new SP("@Company", customer.Company),
                    new SP("@Points", customer.Points),
                    new SP("@LastVisit", customer.LastVisit),
                    new SP("@Photo", customer.Photo));

                return true;
            }
            catch (Exception ex) { }
            return false;

        }

        public Boolean UpdateCustomer(Customer customer)
        {
            try
            {
                var query = string.Format(@"
UPDATE Customer 
SET customer_name = @CustomerName, 
    credit_limit = @CreditLimit,
    discount = @Discount,
    price_type = @PriceType,
    birthday = @Birthday,
    address1 = @Address1,
    address2 = @Address2,
    tel_no = @Telephone,
    fax_no = @Fax,
    date = @DateAdded,
    type = @Type,
    remarks = @Remarks,
    company = @Company,
    points = @Points,
    last_visit = @LastVisit,
    photo = @Photo
Where ID = @ID");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@ID", customer.ID),
                    new SP("@CustomerName", customer.Name),
                    new SP("@CreditLimit", customer.CreditLimit),
                    new SP("@Discount", customer.Discount),
                    new SP("@PriceType", customer.PriceType),
                    new SP("@Birthday", customer.Birthday),
                    new SP("@Address1", customer.Address1),
                    new SP("@Address2", customer.Address2),
                    new SP("@Telephone", customer.Telephone),
                    new SP("@Fax", customer.Fax),
                    new SP("@DateAdded", customer.DateAdded),
                    new SP("@Type", customer.Type),
                    new SP("@Remarks", customer.Remarks),
                    new SP("@Company", customer.Company),
                    new SP("@Points", customer.Points),
                    new SP("@LastVisit", customer.LastVisit),
                    new SP("@Photo", customer.Photo));
                return true;
            }
            catch (Exception ex) { }
            return false;
        }

        public Boolean RemoveCustomer(int id)
        {


            try
            {
                var query = string.Format(@"
DELETE FROM Customer 
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