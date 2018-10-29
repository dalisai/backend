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
    public class CustomerController : Controller
    {
        MySqlCustomerRepository customerRepo = new MySqlCustomerRepository();

        // GET: Customer
        public ActionResult Index()
        {
            var customers = customerRepo.FindCustomers();
            return View(customers);
        }

      

        // GET: Customer/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Add(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customerRepo.SaveCustomer(customer);
                ModelState.Clear();
            }
            return View();
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var dept = customerRepo.FindCustomer((id));
                return View(dept);
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customerRepo.UpdateCustomer(customer);
            }
            return RedirectToAction("Index");
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var dept = customerRepo.FindCustomer((int)id);
                return View(dept);
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                customerRepo.RemoveCustomer(id);
            }
            return RedirectToAction("Index");
        }
    }
}
