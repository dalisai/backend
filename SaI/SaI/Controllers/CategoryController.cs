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
    public class CategoryController : Controller
    {
        List<Category> CategoryList = new List<Category>();
        Category category = new Category();
   
        // GET: Category
        public ActionResult Index()
        {
            using (var category = DBHelper.ExecuteReader(@"
Select * 
From Category")){

                while (category.Read()) {
                    var dataCategory = new Category() {
                        CategoryID = DBHelper.GetInt32(category, 0),
                        Description = DBHelper.GetString(category, 1).ToString()
                    };
                    CategoryList.Add(dataCategory);
                }
            }
            return View(CategoryList);
        }


        // GET: Category/Create
        public ActionResult Add() {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category category) {
            if (ModelState.IsValid) {
                var query = string.Format(@"
INSERT INTO CATEGORY (Description) 
VALUES (@Description)");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@Description", category.Description));
            }
            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = @"
Select * 
FROM Category
Where CategoryID = @CategoryID";
            var reader = DBHelper.ExecuteReader(query, new SP("@CategoryID", id));
            if (reader.Read()) {
                category = new Category() {
                      CategoryID = DBHelper.GetInt32(reader, 0),
                      Description = DBHelper.GetString(reader, 1)
                };
            }
            else {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category) {
            if (ModelState.IsValid) {
                var query = string.Format(@"
UPDATE CATEGORY 
SET Description = @Description
Where CategoryID = @CategoryID");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@CategoryID", category.CategoryID),
                    new SP("@Description", category.Description));
            }
            return RedirectToAction("Index");
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = @"
Select * 
FROM Category
Where CategoryID = @CategoryID";
            var reader = DBHelper.ExecuteReader(query, new SP("@CategoryID", id));
            if (reader.Read()) {
                category = new Category() {
                    CategoryID = DBHelper.GetInt32(reader, 0),
                    Description = DBHelper.GetString(reader, 1)
                };
            }
            else {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            var query = string.Format(@"
DELETE FROM CATEGORY 
Where CategoryID = @CategoryID");
            DBHelper.ExecuteNonQuery(query,
                new SP("@CategoryID", id));
            return RedirectToAction("Index");
        }

    }
}
