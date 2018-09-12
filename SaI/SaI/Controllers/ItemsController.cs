using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaI.Repositories.Sql;
using SaI.Models;

namespace SaI.Controllers
{
    public class ItemsController : Controller
    {
        SqlItemRepository repo = new SqlItemRepository();

        public ActionResult Index()
        {
            var itemList = new Items {
                ItemList = repo.FindItems()
            };
            return View(itemList);
        }

        [Route("items/AddItem/")]
        public ActionResult AddItem()
        {
            return View();
        }

        [Route("items/EditItem/")]
        public ActionResult EditItem()
        {
            return View();
        }

        [Route("items/AddItemDetails/")]
        public ActionResult AddDetails()
        {
            return View();
        }

        [Route("items/EditItemDetails/")]
        public ActionResult EditDetails()
        {
            return View();
        }
    }
}