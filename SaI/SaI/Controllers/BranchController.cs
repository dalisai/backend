using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaI.Repositories.Sql;
using SaI.Models;
using SaI.Helpers;

namespace SaI.Controllers
{
    public class BranchController : Controller
    {
        SqlBranchRepository branchRepository = new SqlBranchRepository();
        public ActionResult Index()
        {
            Branches branches = new Branches();
            branches.BranchList = branchRepository.FindBranch();
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
        public ActionResult Add(FormCollection collection)
        {
            try
            {
                branchRepository.SaveBranch(collection["Description"]);
                //return RedirectToAction("Index");
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var branchData = branchRepository.GetBranch(id);
            return View(branchData);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                branchRepository.UpdateBranch(id, collection["Description"].ToString().Trim());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var branchData = branchRepository.GetBranch(id);
            return View(branchData);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                branchRepository.RemoveBranch(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
