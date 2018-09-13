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
    public class CategoryController : Controller
    {
        MySqlCategoryRepository categoryRepo = new MySqlCategoryRepository();
        // GET: Category
        public ActionResult Index()
        {
            var categories = categoryRepo.FindCategories();
            ViewData["success_message"] = TempData["success_message"];
            return View(categories);
        }

        // GET: Category/Create
        public ActionResult Add() {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category category) {

            if (category.Description != null) {

                if (ModelState.IsValid) {
                    categoryRepo.SaveCategory(category);
                }
                ViewData["success_message"] = "You successfully created" + " " + category.Description + " " + "category.";
            }
            else {
                ViewData["error_message"] = "You unsuccessfully created" + " " + category.Description + " " + "category.";
            }
            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                var category = categoryRepo.FindCategory((int)id);
                return View(category);
            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category) {
            if (ModelState.IsValid) {
                if (category.Description != null) {
                    categoryRepo.UpdateCategory(category);
                }
                TempData["success_message"] = "You successfully edited" + " " + category.Description + " " + "category.";
            }
            else {
                TempData["success_message"] = "You unsuccessfully edited" + " " + category.Description + " " + "category.";
            }
            return RedirectToAction("Index");
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                var category = categoryRepo.FindCategory((int)id);
                return View(category);
            }
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id) {
            if (id != 0) {
                categoryRepo.RemoveCategory(id);
                TempData["success_message"] = "You successfully deleted" + " " + id + " " + "category.";
            }         
            else {
                TempData["success_message"] = "You unsuccessfully deleted" + " " + id + " " + "category.";
            }
            return RedirectToAction("Index");
        }

    }
}
