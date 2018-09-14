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
    public class BranchController : Controller
    {
        MySqlBranchRepository branchRepository = new MySqlBranchRepository();
        public ActionResult Index()
        {
            Branches branches = new Branches();
            branches.BranchList = branchRepository.FindBranch();
            ViewData["success_message"] = TempData["success_message"];
            return View(branches.BranchList);
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
        public ActionResult Add(Branch branch)
        {
            try
            {
                if(branch.Description != null) {
                    if (ModelState.IsValid) {
                        branchRepository.SaveBranch(branch.Description.Trim());
                        ViewData["success_message"] = "New branch successfully saved.";
                        ModelState.Clear();
                    }
                }
                else {
                    ViewData["error_message"] = "Branch name cannot be empty. Please input branch name then save.";
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
                var branchData = branchRepository.GetBranch(Convert.ToInt32(id));
                return View(branchData);
            }
        }

        [HttpPost]
        public ActionResult Edit(Branch branch)
        {
            try {
                if (branch.Description != null) {
                    if (ModelState.IsValid) {
                        branchRepository.UpdateBranch(branch.ID, branch.Description.Trim());
                        TempData["success_message"] = "Branch successfully updated.";
                        return RedirectToAction("Index");
                    }
                }
                else {
                    ViewData["error_message"] = "Branch name cannot be empty. Please input branch name then save.";
                }
                return View();
            }
            catch (Exception ex) {
                ViewData["error_message"] = "Found some error during updating of data. " + ex.Message.ToString();
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var branchData = branchRepository.GetBranch(id);
            return View(branchData);
        }

        [HttpPost]
        public ActionResult Delete(Branch branch)
        {
            try
            {
                branchRepository.RemoveBranch(branch.ID);
                TempData["success_message"] = "Branch successfully removed.";
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
