using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SaI.Models;
using SaI.Helpers;
using SP = MySql.Data.MySqlClient.MySqlParameter;
namespace SaI.Controllers
{
    public class SupplierController : Controller
    {
        List<Supplier> SupplierList = new List<Supplier>();
        Supplier supplier = new Supplier();

        // GET: Supplier
        public ActionResult Index()
        {
            using (var supplier = DBHelper.ExecuteReader(@"
Select * 
From Supplier")){

                while (supplier.Read()) {
                    var dataSupplier = new Supplier() {
                        SupplierID = DBHelper.GetInt32(supplier, 0),
                        Description = DBHelper.GetString(supplier, 1).ToString()
                    };
                    SupplierList.Add(dataSupplier);
                }
            }
            ViewData["success_message"] = TempData["success_message"];
            return View(SupplierList);
        }


        // GET: Supplier/Create
        public ActionResult Add() {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Supplier supplier) {
            if (ModelState.IsValid) {
                if (supplier.Description != null) {
                    var query = string.Format(
                    @"
INSERT INTO Supplier (Description) 
VALUES (@Description)");
                    DBHelper.ExecuteNonQuery(query,
                        new SP("@Description", supplier.Description));
                }
                ViewData["success_message"] = "You successfully created" + " " + supplier.Description + " " + "category.";
            }
            else {
                ViewData["error_message"] = "You unsuccessfully created" + " " + supplier.Description + " " + "category.";
            }
            return View(supplier);
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = @"
Select * 
FROM Supplier
Where SupplierID = @SupplierID";
            var reader = DBHelper.ExecuteReader(query, new SP("@SupplierID", id));
            if (reader.Read()) {
                supplier = new Supplier() {
                      SupplierID = DBHelper.GetInt32(reader, 0),
                      Description = DBHelper.GetString(reader, 1)
                };
            }
            else {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier) {
            if (ModelState.IsValid) {
                if (supplier.Description != null) {
                    var query = string.Format(
        @"
UPDATE Supplier 
SET Description = @Description
Where SupplierID = @SupplierID");
                    DBHelper.ExecuteNonQuery(query,
                        new SP("@SupplierID", supplier.SupplierID),
                        new SP("@Description", supplier.Description));
                }
                TempData["success_message"] = "You successfully edited" + " " + supplier.Description + " " + "category.";
            }
            else {
                TempData["success_message"] = "You unsuccessfully edited" + " " + supplier.Description + " " + "category.";
            }
            return RedirectToAction("Index");
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = @"
Select * 
FROM Supplier
Where SupplierID = @SupplierID";
            var reader = DBHelper.ExecuteReader(query, new SP("@SupplierID", id));
            if (reader.Read()) {
                supplier = new Supplier() {
                    SupplierID = DBHelper.GetInt32(reader, 0),
                    Description = DBHelper.GetString(reader, 1)
                };
            }
            else {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            if (id != 0) {
                var query = string.Format(
@"
DELETE FROM Supplier 
Where SupplierID = @SupplierID");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@SupplierID", id));
                TempData["success_message"] = "You successfully deleted" + " " + id + " " + "category.";
            }
            else {
                TempData["success_message"] = "You unsuccessfully deleted" + " " + id + " " + "category.";
            }
            return RedirectToAction("Index");
        }

    }
}
