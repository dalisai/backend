using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SaI.Models;
using SaI.Repositories.MySql;

namespace SaI.Controllers
{
    public class DepartmentController : Controller
    {
        MySqlDepartmentRepository departmentRepo = new MySqlDepartmentRepository();
        // GET: Department
        public ActionResult Index()
        {
            var departments = departmentRepo.FindDepartments();
            return View(departments);
        }

        public ActionResult Add()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Department department)
        {
            if (ModelState.IsValid)
            {
                
                departmentRepo.SaveDepartment(department);
            }
            return View(department);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                var dept = departmentRepo.FindDepartment((int)id);
                return View(dept);
            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid){
                departmentRepo.UpdateDepartment(department);                
            }
            return RedirectToAction("Index");
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var dept = departmentRepo.FindDepartment((int)id);
                return View(dept);
            }
            
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                departmentRepo.RemoveDepartment(id);
            }
            return RedirectToAction("Index");
        }
    }
}