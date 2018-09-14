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
    public class PaymentController : Controller
    {
        MySqlPaymentRepository paymentRepository = new MySqlPaymentRepository();
        public ActionResult Index()
        {
            Payments payments = new Payments();
            payments.PaymentList = paymentRepository.FindPayment();
            ViewData["success_message"] = TempData["success_message"];
            return View(payments.PaymentList);
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
        public ActionResult Add(Payment payment)
        {
            try {
                if (payment.Description != null) {
                    if (ModelState.IsValid) {
                        paymentRepository.SavePayment(payment.Description, payment.Ratio);
                        ViewData["success_message"] = "Payment successfully saved.";
                        ModelState.Clear();
                    }
                }
                else {
                    ViewData["error_message"] = "Payment entry not saved, please check your input details.";
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
                var paymentData = paymentRepository.GetPayment(Convert.ToInt32(id));
                return View(paymentData);
            }
        }

        [HttpPost]
        public ActionResult Edit(Payment payment)
        {
            try {
                if (payment.Description != null) {
                    if (ModelState.IsValid) {
                        paymentRepository.UpdatePayment(payment.ID, payment.Description, payment.Ratio);
                        TempData["success_message"] = "Payment successfully updated.";
                        return RedirectToAction("Index");
                    }
                }
                else {
                    ViewData["error_message"] = "Payment entry not saved, please check your input details.";
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
                var paymentData = paymentRepository.GetPayment(Convert.ToInt32(id));
                return View(paymentData);
            }
        }

        [HttpPost]
        public ActionResult Delete(Payment payment)
        {
            try {
                paymentRepository.RemovePayment(payment.ID);
                TempData["success_message"] = "Payment successfully removed.";
                return RedirectToAction("Index");
            }
            catch (Exception ex) {
                ViewData["error_message"] = "Found some error during removing of data. " + ex.Message.ToString();
                return View();
            }
        }
    }
}
