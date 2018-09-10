using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using SaI.Helpers;
//using MySql.Data.MySqlClient;

namespace SaI.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
//            var query = @"
//SELECT * 
//FROM Items 
//WHERE itemcode = @itemcode;";
//            var data = DBHelper.ExecuteReader(query, new MySqlParameter("@itemcode", 1));
//            if (data.HasRows) {
//                Console.WriteLine(true);
//            }
            return View();
        }
    }
}