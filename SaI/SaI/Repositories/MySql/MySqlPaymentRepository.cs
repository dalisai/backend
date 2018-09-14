using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaI.Models;
using SaI.Helpers;
using SP = MySql.Data.MySqlClient.MySqlParameter;

namespace SaI.Repositories.MySql
{
    public class MySqlPaymentRepository
    {
        public List<Payment> FindPayment()
        {
            var payments = new List<Payment>();
            string query = @"
SELECT ID, 
    payment, 
    amount 
FROM payment_entry";
            var rs = DBHelper.ExecuteReader(query);
            while (rs.Read()) {
                var payment = new Payment {
                    ID = DBHelper.GetInt32(rs, 0),
                    Description = DBHelper.GetString(rs, 1),
                    Ratio = DBHelper.GetDecimal(rs, 2)
                };
                payments.Add(payment);
            }
            return payments;
        }

        public Payment GetPayment(int id)
        {
            Payment paymentData = new Payment();
            string query = @"
SELECT ID, 
    payment, 
    amount 
FROM payment_entry 
WHERE id = @ID";
            var rs = DBHelper.ExecuteReader(query, new SP("@ID", id));
            while (rs.Read()) {
                paymentData = new Payment {
                    ID = DBHelper.GetInt32(rs, 0),
                    Description = DBHelper.GetString(rs, 1), 
                    Ratio = DBHelper.GetDecimal(rs, 2)
                };
            }
            return paymentData;
        }

        public bool SavePayment(string description, decimal ratio)
        {
            string query = @"
INSERT INTO payment_entry (payment, amount) 
VALUES (@Payment, @Amount)";
            DBHelper.ExecuteNonQuery(query, new SP("@Payment", description), new SP("@Amount", ratio));
            return true;
        }

        public bool UpdatePayment(int id, string description, decimal ratio)
        {
            string query = @"
UPDATE payment_entry SET payment = @Payment, 
    amount = @Amount 
WHERE id = @ID";
            DBHelper.ExecuteNonQuery(query, new SP("@Payment", description), new SP("@Amount", ratio), new SP("@ID", id));
            return true;
        }

        public bool RemovePayment(int? id)
        {
            string query = @"
DELETE FROM payment_entry 
WHERE id = @ID";
            DBHelper.ExecuteNonQuery(query, new SP("@ID", id));
            return true;
        }
    }
}