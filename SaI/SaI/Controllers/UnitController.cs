using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaI.Repositories.MySql;
using SaI.Models;
using SaI.Helpers;
using System.Net;

namespace SaI.Controllers
{
    public class UnitController : Controller
    {
        MySqlUnitRepository unitRepository = new MySqlUnitRepository();
        public ActionResult Index()
        {
            Units units = new Units();
            units.UnitList = unitRepository.FindUnits();
            ViewData["success_message"] = TempData["success_message"];
            return View(units.UnitList);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Unit unit)
        {
            try
            {
                if(unit.Description != null) {
                    if (ModelState.IsValid) {
                        unitRepository.SaveUnit(unit.Description);
                        ViewData["success_message"] = "New unit successfully saved.";
                        ModelState.Clear();
                    }
                }
                else {
                    ViewData["error_message"] = "Unit name cannot be empty. Please input unit name then save.";
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewData["error_message"] = "Found some error during saving of data. " + ex.Message.ToString();
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                var unitData = unitRepository.GetUnit(Convert.ToInt32(id));
                return View(unitData);
            }
        }

        [HttpPost]
        public ActionResult Edit(Unit unit)
        {
            try {
                if (unit.Description != null) {
                    if (ModelState.IsValid) {
                        unitRepository.UpdateUnit(unit.ID, unit.Description);
                        TempData["success_message"] = "Unit successfully updated.";
                        return RedirectToAction("Index");
                    }
                }
                else {
                    ViewData["error_message"] = "Unit name cannot be empty. Please input unit name then save.";
                }
                return View();
            }
            catch (Exception ex) {
                ViewData["error_message"] = "Found some error during updating of data. " + ex.Message.ToString();
                return View();
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                var unitData = unitRepository.GetUnit(Convert.ToInt32(id));
                return View(unitData);
            }
        }

        [HttpPost]
        public ActionResult Delete(Unit unit)
        {
            try
            {
                unitRepository.RemoveUnit(unit.ID);
                TempData["success_message"] = "Unit successfully removed.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["error_message"] = "Found some error during removing of data. " + ex.Message.ToString();
                return View();
            }
        }
    }
}
