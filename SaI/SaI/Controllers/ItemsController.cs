using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaI.Repositories.MySql;
using SaI.Models;
using SaI.Helpers;

namespace SaI.Controllers
{
    public class ItemsController : Controller
    {
        MySqlItemRepository itemRepository = new MySqlItemRepository();

        public ActionResult Index()
        {
            var itemList = new Items {
                ItemList = itemRepository.FindItems()
            };
            return View(itemList);
        }

        [Route("items/AddItem/")]
        public ActionResult AddItem()
        {
            var query = @"
SELECT * FROM dept";
            return View();
        }

        [Route("items/AddItem/")]
        [HttpPost]
        public ActionResult AddItem(Item item)
        {
            if (ModelState.IsValid) {

            }
            return View();
        }

        [Route("items/EditItem/")]
        public ActionResult EditItem(int? id)
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