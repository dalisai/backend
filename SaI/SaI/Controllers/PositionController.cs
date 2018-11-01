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
    public class PositionController : Controller
    {
        MySqlPositionRepository positionRepo = new MySqlPositionRepository();


        // GET: Position
        public ActionResult Index()
        {
            var positions = positionRepo.FindPositions();
            ViewData["success_message"] = TempData["success_message"];
            ViewData["error_message"] = TempData["error_message"];
            return View(positions);
        }

        // GET: Position/Create
        public ActionResult Add() {
            return View();
        }

        // POST: Position/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Position position) {
            if (position.Name != null) {
                bool exist = positionRepo.IsPositionExist(position.Name);
                if (exist == false) {
                    if (ModelState.IsValid) {
                        var addPosition = positionRepo.SavePosition(position);
                        if (addPosition == true) {
                            ModelState.Clear();
                            ViewData["success_message"] = "You successfully created" + " " + position.Name + " " + "position.";
                        }
                        else {
                            ViewData["error_message"] = "You unsuccessfully created" + " " + position.Name + " " + "position.";
                        }
                    }
                }
                else {
                    ViewData["error_message"] = "The description" + " " + position.Name + " " + "position already exist.";
                }
            }
            else {
                ViewData["error_message"] = "You unsuccessfully created" + " " + position.Name + " " + "position.";
            }
            return View();
        }

        // GET:Position/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                var position = positionRepo.FindPosition((int)id);
                return View(position);
            }
        }

        // POST: Position/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Position position) {
            if (position.Name != null) {
                bool exist = positionRepo.IsPositionExist(position.Name);
                if (exist == false) {
                    if (ModelState.IsValid) {
                        positionRepo.UpdatePosition(position);
                        TempData["success_message"] = "You successfully edited" + " " + position.Name + " " + "position.";
                    }
                }
                else {
                    TempData["error_message"] = "The description" + " " + position.Name + " " + "position already exist.";
                }
            }
            else {
                TempData["error_message"] = "You unsuccessfully edited" + " " + position.Name + " " + "position.";
            }
            return RedirectToAction("Index");
        }

        // GET: Position/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                var position = positionRepo.FindPosition((int)id);
                return View(position);
            }
        }

        // POST: Position/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id) {
            if (id != 0) {
                positionRepo.RemovePosition(id);
                TempData["success_message"] = "You successfully deleted" + " " + id + " " + "position.";
            }         
            else {
                TempData["success_message"] = "You unsuccessfully deleted" + " " + id + " " + "position.";
            }
            return RedirectToAction("Index");
        }

    }
}
