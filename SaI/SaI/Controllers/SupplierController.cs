﻿using System;
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
    public class SupplierController : Controller
    {
        MySqlSupplierRepository supplierRepo = new MySqlSupplierRepository();
        // GET: Supplier
        public ActionResult Index()
        {
            var suppliers = supplierRepo.FindSuppliers();
            ViewData["success_message"] = TempData["success_message"];
            ViewData["error_message"] = TempData["error_message"];
            return View(suppliers);
        }

        // GET: Supplier/Create
        public ActionResult Add() {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Supplier supplier) {
            if (supplier.Description != null) {
                bool exist = supplierRepo.IsSupplierExist(supplier.Description);
                if (exist == false) {
                    if (ModelState.IsValid) {
                        var addsupplier = supplierRepo.SaveSupplier(supplier);
                        if (addsupplier == true) {
                            ModelState.Clear();
                            ViewData["success_message"] = "You successfully created" + " " + supplier.Description + " " + "supplier.";
                        }
                        else {
                            ViewData["error_message"] = "You unsuccessfully created" + " " + supplier.Description + " " + "supplier.";
                        }
                    }
                }
                else {
                    ViewData["error_message"] = "The description" + " " + supplier.Description + " " + "supplier already exist.";
                }
            }
            else {
                ViewData["error_message"] = "You unsuccessfully created" + " " + supplier.Description + " " + "supplier.";
            }
            return View();
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                var supplier = supplierRepo.FindSupplier((int)id);
                return View(supplier);
            }
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier) {
            if (supplier.Description != null) {
                bool exist = supplierRepo.IsSupplierExist(supplier.Description);
                if (exist == false) {
                    if (ModelState.IsValid) {
                        supplierRepo.UpdateSupplier(supplier);
                        TempData["success_message"] = "You successfully edited" + " " + supplier.Description + " " + "supplier.";
                    }
                }
                else {
                    TempData["error_message"] = "The description" + " " + supplier.Description + " " + "supplier already exist.";
                }
            }
            else {
                TempData["error_message"] = "You unsuccessfully edited" + " " + supplier.Description + " " + "supplier.";
            }
            return RedirectToAction("Index");
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                var supplier = supplierRepo.FindSupplier((int)id);
                return View(supplier);
            }
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id) {
            if (id != 0) {
                supplierRepo.RemoveSupplier(id);
                TempData["success_message"] = "You successfully deleted" + " " + id + " " + "supplier.";
            }         
            else {
                TempData["success_message"] = "You unsuccessfully deleted" + " " + id + " " + "supplier.";
            }
            return RedirectToAction("Index");
        }

    }
}
