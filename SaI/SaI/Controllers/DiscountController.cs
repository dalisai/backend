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
    public class DiscountController : Controller
    {
        MySqlDiscountRepository discountRepo = new MySqlDiscountRepository();
        // GET: Discount
        public ActionResult Index()
        {
            var discounts = discountRepo.FindDiscounts();
            return View(discounts);
        }


        // GET: Discount/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Discount/Create
        [HttpPost]
        public ActionResult Add(Discount discount)
        {
            if (ModelState.IsValid)
            {

                discountRepo.SaveDiscount(discount);
                ModelState.Clear();
            }
            return View();
        }

        // GET: Discount/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var dept = discountRepo.FindDiscount((int)id);
                return View(dept);
            }
        }

        // POST: Discount/Edit/5
        [HttpPost]
        public ActionResult Edit(Discount discount)
        {
            if (ModelState.IsValid)
            {
                discountRepo.UpdateDiscount(discount);
            }
            return RedirectToAction("Index");
        }

        // GET: Discount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var dept = discountRepo.FindDiscount((int)id);
                return View(dept);
            }
        }

        // POST: Discount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                discountRepo.RemoveDiscount(id);
            }
            return RedirectToAction("Index");
        }
    }
}
