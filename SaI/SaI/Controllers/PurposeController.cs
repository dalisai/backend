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
    public class PurposeController : Controller
    {
        MySqlPurposeRepository purposeRepository = new MySqlPurposeRepository();
        public ActionResult Index()
        {
            Purposes purposes = new Purposes();
            purposes.PurposeList = purposeRepository.FindPurpose();
            ViewData["success_message"] = TempData["success_message"];
            return View(purposes.PurposeList);
        }

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Purpose purpose)
        {
            try {
                if (purpose.Description != null) {
                    if (ModelState.IsValid) {
                        purposeRepository.SavePurpose(purpose.Description);
                        ViewData["success_message"] = "Purpose successfully saved.";
                    }
                }
                else {
                    ViewData["error_message"] = "Purpose cannot be empty. Please input purpose name then save.";
                }
                return View();
            }
            catch (Exception ex) {
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
                var purposeData = purposeRepository.GetPurpose(Convert.ToInt32(id));
                return View(purposeData);
            }
        }

        [HttpPost]
        public ActionResult Edit(Purpose purpose)
        {
            try {
                if (purpose.Description != null) {
                    if (ModelState.IsValid) {
                        purposeRepository.UpdatePurpose(purpose.ID, purpose.Description.Trim());
                        TempData["success_message"] = "Purpose successfully updated.";
                        return RedirectToAction("Index");
                    }
                }
                else {
                    ViewData["error_message"] = "Purpose cannot be empty. Please input purpose name then save.";
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
                var purposeData = purposeRepository.GetPurpose(Convert.ToInt32(id));
                return View(purposeData);
            }
        }

        [HttpPost]
        public ActionResult Delete(Purpose purpose)
        {
            try {
                purposeRepository.RemovePurpose(purpose.ID);
                TempData["success_message"] = "Purpose successfully removed.";
                return RedirectToAction("Index");
            }
            catch (Exception ex) {
                ViewData["error_message"] = "Found some error during removing of data. " + ex.Message.ToString();
                return View();
            }
        }
    }
}
