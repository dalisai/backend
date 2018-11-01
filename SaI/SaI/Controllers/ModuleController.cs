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
    public class ModuleController : Controller
    {
        MySqlModuleRepository moduleRepo = new MySqlModuleRepository();


        // GET: Module
        public ActionResult Index()
        {
            var modules = moduleRepo.FindModules();
            ViewData["success_message"] = TempData["success_message"];
            ViewData["error_message"] = TempData["error_message"];
            return View(modules);
        }

        // GET: Module/Create
        public ActionResult Add() {
            return View();
        }

        // POST: Module/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Module module) {
            if (module.Name != null) {
                bool exist = moduleRepo.IsModuleExist(module.Name);
                if (exist == false) {
                    if (ModelState.IsValid) {
                        var addmodule = moduleRepo.SaveModule(module);
                        if (addmodule == true) {
                            ModelState.Clear();
                            ViewData["success_message"] = "You successfully created" + " " + module.Name + " " + "module.";
                        }
                        else {
                            ViewData["error_message"] = "You unsuccessfully created" + " " + module.Name + " " + "module.";
                        }
                    }
                }
                else {
                    ViewData["error_message"] = "The description" + " " + module.Name + " " + "module already exist.";
                }
            }
            else {
                ViewData["error_message"] = "You unsuccessfully created" + " " + module.Name + " " + "module.";
            }
            return View();
        }

        // GET:Module/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                var position = moduleRepo.FindModule((int)id);
                return View(position);
            }
        }

        // POST: Module/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Module module) {
            if (module.Name != null) {
                bool exist = moduleRepo.IsModuleExist(module.Name);
                if (exist == false) {
                    if (ModelState.IsValid) {
                        moduleRepo.UpdateModule(module);
                        TempData["success_message"] = "You successfully edited" + " " + module.Name + " " + "module.";
                    }
                }
                else {
                    TempData["error_message"] = "The description" + " " + module.Name + " " + "module already exist.";
                }
            }
            else {
                TempData["error_message"] = "You unsuccessfully edited" + " " + module.Name + " " + "module.";
            }
            return RedirectToAction("Index");
        }

        // GET: Module/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                var module = moduleRepo.FindModule((int)id);
                return View(module);
            }
        }

        // POST: Module/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id) {
            if (id != 0) {
                moduleRepo.RemoveModule(id);
                TempData["success_message"] = "You successfully deleted" + " " + id + " " + " module.";
            }         
            else {
                TempData["success_message"] = "You unsuccessfully deleted" + " " + id + " " + " module.";
            }
            return RedirectToAction("Index");
        }

    }
}
