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
using SaI.Repositories.MySql;
namespace SaI.Controllers
{
    public class SubCategoryController : Controller
    {
        MySqlSubCategoryRepository subcategoryRepo = new MySqlSubCategoryRepository();
        // GET: SubCategory
        public ActionResult Index()
        {
            var subcategories = subcategoryRepo.FindSubCategories();
            ViewData["success_message"] = TempData["success_message"];
            ViewData["error_message"] = TempData["error_message"];
            return View(subcategories);
        }

        // GET: SubCategory/Create
        public ActionResult Add() {
            return View();
        }

        // POST: SubCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SubCategory subCategory) {

            if (subCategory.Description != null) {
                bool exist = subcategoryRepo.IsSubCategoryExist(subCategory.Description);
                if (exist == false) {
                    if (ModelState.IsValid) {
                        subcategoryRepo.SaveSubCategory(subCategory);
                        ViewData["success_message"] = "You successfully created" + " " + subCategory.Description + " " + "subCategory.";
                    }
                }
                else {
                    ViewData["error_message"] = "The description" + " " + subCategory.Description + " " + "subCategory already exist.";
                }
            }
            else {
                ViewData["error_message"] = "You unsuccessfully created" + " " + subCategory.Description + " " + "subCategory.";
            }
            ModelState.Clear();
            return View(subCategory);
        }

        // GET: Subcategory/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                var category = subcategoryRepo.FindSubCategory((int)id);
                return View(category);
            }
        }

        // POST: Subcategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubCategory subcategory) {
            if (subcategory.Description != null) {
                bool exist = subcategoryRepo.IsSubCategoryExist(subcategory.Description);
                if (exist == false) {
                    subcategoryRepo.UpdateSubCategory(subcategory);
                    TempData["success_message"] = "You successfully edited" + " " + subcategory.Description + " " + "subcategory.";
                }
                else {
                    TempData["error_message"] = "The description" + " " + subcategory.Description + " " + "subcategory already exist.";
                }
            }
            else {
                TempData["success_message"] = "You unsuccessfully edited" + " " + subcategory.Description + " " + "subcategory.";
            }
            return RedirectToAction("Index");
        }

        // GET: Subcategory/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                var subcategory = subcategoryRepo.FindSubCategory((int)id);
                return View(subcategory);
            }
        }

        // POST: Subcategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id) {
            if (id != 0) {
                subcategoryRepo.RemoveSubCategory(id);
                TempData["success_message"] = "You successfully deleted" + " " + id + " " + " subcategory.";
            }         
            else {
                TempData["success_message"] = "You unsuccessfully deleted" + " " + id + " " + " subcategory.";
            }
            return RedirectToAction("Index");
        }

    }
}
