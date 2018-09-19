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
    public class LocationController : Controller
    {
        MySqlLocationRepository locationRepository = new MySqlLocationRepository();
        public ActionResult Index()
        {
            Locations locations = new Locations();
            locations.LocationList = locationRepository.FindLocation();
            ViewData["success_message"] = TempData["success_message"];
            return View(locations.LocationList);
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
        public ActionResult Add(Location location)
        {
            try {
                if (location.Description != null) {
                    if (ModelState.IsValid) {
                        locationRepository.SaveLocation(location.Description);
                        ViewData["success_message"] = "Location successfully saved.";
                        ModelState.Clear();
                    }
                }
                else {
                    ViewData["error_message"] = "Location cannot be empty. Please input location name then save.";
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
                var locationData = locationRepository.GetLocation(Convert.ToInt32(id));
                return View(locationData);
            }
        }

        [HttpPost]
        public ActionResult Edit(Location location)
        {
            try {
                if (location.Description != null) {
                    if (ModelState.IsValid) {
                        locationRepository.UpdateLocation(location.ID, location.Description.Trim());
                        TempData["success_message"] = "Location successfully updated.";
                        return RedirectToAction("Index");
                    }
                }
                else {
                    ViewData["error_message"] = "Location cannot be empty. Please input location name then save.";
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
                var locationData = locationRepository.GetLocation(Convert.ToInt32(id));
                return View(locationData);
            }
        }

        [HttpPost]
        public ActionResult Delete(Location location)
        {
            try {
                locationRepository.RemoveLocation(location.ID);
                TempData["success_message"] = "Location successfully removed.";
                return RedirectToAction("Index");
            }
            catch (Exception ex) {
                ViewData["error_message"] = "Found some error during removing of data. " + ex.Message.ToString();
                return View();
            }
        }
    }
}
