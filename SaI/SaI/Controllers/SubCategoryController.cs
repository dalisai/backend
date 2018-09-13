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
    public class SubCategoryController : Controller
    {
        List<SubCategory> SubCategoryList = new List<SubCategory>();
        SubCategory subCategory = new SubCategory();

        // GET: SubCategory
        public ActionResult Index()
        {

            using (var subcategory = DBHelper.ExecuteReader(@"
Select * 
From SubCategory")){

                while (subcategory.Read()) {

                    var datasubcategory = new SubCategory() {
                        SubCategoryID = DBHelper.GetInt32(subcategory, 0),
                        Description = DBHelper.GetString(subcategory, 1).ToString()
                    };
                    SubCategoryList.Add(datasubcategory);
                }
            }
            ViewData["success_message"] = TempData["success_message"];
            return View(SubCategoryList);
        }


        // GET: SubCategory/Create
        public ActionResult Add() {
            return View();
        }

        // POST: SubCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SubCategory subcategory) {
            if (ModelState.IsValid) {
                if (subcategory.Description != null) {
                    var query = string.Format(
                    @"
INSERT INTO SubCategory (Description) 
VALUES (@Description)");
                    DBHelper.ExecuteNonQuery(query,
                        new SP("@Description", subcategory.Description));
                }
                ViewData["success_message"] = "You successfully created" + " " + subcategory.Description + " " + "category.";
            }
            else {
                ViewData["error_message"] = "You unsuccessfully created" + " " + subcategory.Description + " " + "category.";
            }
            return View(subcategory);
        }

        // GET: SubCategory/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = @"
Select * 
FROM SubCategory
Where SubCategoryID = @SubCategoryID";
            var reader = DBHelper.ExecuteReader(query, new SP("@SubCategoryID", id));
            if (reader.Read()) {
                subCategory = new SubCategory() {
                      SubCategoryID = DBHelper.GetInt32(reader, 0),
                      Description = DBHelper.GetString(reader, 1)
                };
            }
            else {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // POST: SubCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubCategory subcategory) {
            if (ModelState.IsValid) {
                if (subcategory.Description != null) {
                    var query = string.Format(@"
UPDATE SubCategory
SET Description = @Description
Where SubCategoryID = @SubCategoryID");
                    DBHelper.ExecuteNonQuery(query,
                        new SP("@SubCategoryID", subcategory.SubCategoryID),
                        new SP("@Description", subcategory.Description));
                }
                TempData["success_message"] = "You successfully edited" + " " + subcategory.Description + " " + "category.";
            }
            else {
                TempData["success_message"] = "You unsuccessfully edited" + " " + subcategory.Description + " " + "category.";
            }
            return RedirectToAction("Index");
        }

        // GET: SubCategory/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = @"
Select * 
FROM SubCategory
Where SubCategoryID = @SubCategoryID";
            var reader = DBHelper.ExecuteReader(query, new SP("@SubCategoryID", id));
            if (reader.Read()) {
                subCategory = new SubCategory() {
                    SubCategoryID = DBHelper.GetInt32(reader, 0),
                    Description = DBHelper.GetString(reader, 1)
                };
            }
            else {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // POST: SubCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            if (id != 0) {
                var query = string.Format(@"
DELETE FROM SubCategory 
Where SubCategoryID = @SubCategoryID");
                DBHelper.ExecuteNonQuery(query,
                    new SP("@SubCategoryID", id));

                TempData["success_message"] = "You successfully deleted" + " " + id + " " + "category.";
            }
            else {
                TempData["success_message"] = "You unsuccessfully deleted" + " " + id + " " + "category.";
            }
            return RedirectToAction("Index");
         
        }

    }
}
