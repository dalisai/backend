using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaI.Repositories.MySql;
using SaI.Models;
using SaI.ViewModel;
using System.Net;

namespace SaI.Controllers
{
    public class ItemsController : Controller
    {
        MySqlItemRepository itemRepository = new MySqlItemRepository();
        MySqlDepartmentRepository departmentRepository = new MySqlDepartmentRepository();
        MySqlCategoryRepository categoryRepository = new MySqlCategoryRepository();
        MySqlSubCategoryRepository subCategoryRepository = new MySqlSubCategoryRepository();
        MySqlSupplierRepository supplierRepository = new MySqlSupplierRepository();
        MySqlUnitRepository unitRepository = new MySqlUnitRepository();
        ItemViewModel viewModelData;

        public ActionResult Index()
        {
            var itemList = new Items {
                ItemList = itemRepository.FindItems()
            };
            ViewData["success_message"] = TempData["success_message"];
            return View(itemList);
        }

        public ActionResult AddItem(int? id)
        {
            if (TempData["error_message"] != null)
                ViewData["error_message"] = TempData["error_message"];
            Item item = new Item();
            List<ItemDetail> itemDetails = new List<ItemDetail>();
            var deparment = departmentRepository.FindDepartments();
            var category = categoryRepository.FindCategories();
            var subCategory = subCategoryRepository.FindSubCategories();
            var supplier = supplierRepository.FindSuppliers();
            var unit = unitRepository.FindUnits();
            if (id != null) 
                item = itemRepository.GetItem(Convert.ToInt32(id));
            if(item != null)
                itemDetails = itemRepository.FindItemDetails(item);
            else
                item = new Item();


            viewModelData = new ItemViewModel {
                DepartmentList = deparment,
                CategoryList = category,
                SubCategoryList = subCategory,
                SupplierList = supplier,
                UnitList = unit,
                Item = item,
                ItemDetailList = itemDetails
            };

            return View(viewModelData);
        }

        [HttpPost]
        public ActionResult AddItem(Item item)
        {
            try {
                var deparment = departmentRepository.FindDepartments();
                var category = categoryRepository.FindCategories();
                var subCategory = subCategoryRepository.FindSubCategories();
                var supplier = supplierRepository.FindSuppliers();
                var unit = unitRepository.FindUnits();

                viewModelData = new ItemViewModel {
                    DepartmentList = deparment,
                    CategoryList = category,
                    SubCategoryList = subCategory,
                    SupplierList = supplier,
                    UnitList = unit
                };

                if (item.LongDescription != null && item.ShortDescription != null) {
                    if (ModelState.IsValid) {
                        int itemSave = itemRepository.SaveItem(item);
                        if (itemSave != 0) {
                            ViewData["success_message"] = "New item successfully saved.";
                            viewModelData.Item = itemRepository.GetItem(itemSave);
                        }
                        else {
                            ViewData["error_message"] = "Found some error during saving of data.";
                        }

                        //ModelState.Clear();
                        //return View(viewModelData);
                        return RedirectToAction("EditItem", new { id = viewModelData.Item.ID });
                    }
                }
                else {
                    ViewData["error_message"] = "Item descriptions cannot be empty. Please input item descriptions then save.";
                }
                return View(viewModelData);
            }
            catch (Exception ex) {
                ViewData["error_message"] = "Found some error during saving of data. " + ex.Message.ToString();
                return View(viewModelData);
            }
        }

        public ActionResult EditItem(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                if (TempData["success_message"] != null)
                    ViewData["success_message"] = TempData["success_message"];
                Item item = new Item();
                List<ItemDetail> itemDetails = new List<ItemDetail>();
                var deparment = departmentRepository.FindDepartments();
                var category = categoryRepository.FindCategories();
                var subCategory = subCategoryRepository.FindSubCategories();
                var supplier = supplierRepository.FindSuppliers();
                var unit = unitRepository.FindUnits();
                if (id != null)
                    item = itemRepository.GetItem(Convert.ToInt32(id));
                if (item != null)
                    itemDetails = itemRepository.FindItemDetails(item);
                else
                    item = new Item();

                viewModelData = new ItemViewModel {
                    DepartmentList = deparment,
                    CategoryList = category,
                    SubCategoryList = subCategory,
                    SupplierList = supplier,
                    UnitList = unit,
                    Item = item,
                    ItemDetailList = itemDetails
                };
                return View(viewModelData);
            }
        }

        [HttpPost]
        public ActionResult EditItem(Item item)
        {
            try {
                var deparment = departmentRepository.FindDepartments();
                var category = categoryRepository.FindCategories();
                var subCategory = subCategoryRepository.FindSubCategories();
                var supplier = supplierRepository.FindSuppliers();
                var unit = unitRepository.FindUnits();

                viewModelData = new ItemViewModel {
                    DepartmentList = deparment,
                    CategoryList = category,
                    SubCategoryList = subCategory,
                    SupplierList = supplier,
                    UnitList = unit,
                    Item = item
                };

                if (item.LongDescription != null && item.ShortDescription != null) {
                    if (ModelState.IsValid) {
                        itemRepository.UpdateItem(item);
                        TempData["success_message"] = "Item successfully updated.";
                        return RedirectToAction("Index");
                    }
                }
                else {
                    ViewData["error_message"] = "Item descriptions cannot be empty. Please input item descritpions then save.";
                }
                return View(viewModelData);
            }
            catch (Exception ex) {
                ViewData["error_message"] = "Found some error during updating of data. " + ex.Message.ToString();
                return View(viewModelData);
            }
        }

        public ActionResult AddDetail(int? id)
        {
            if (id == null || id == 0) {
                TempData["error_message"] = "Please create item first before creating the item details.";
                return RedirectToAction("AddItem");
            }
            var itemViewModel = new ItemViewModel {
                Item = itemRepository.GetItem(Convert.ToInt32(id))
            };
            return View(itemViewModel);
        }

        [HttpPost]
        public ActionResult AddDetail(Item item, ItemDetail itemDetail)
        {
            itemDetail.ItemDetailCode = Convert.ToInt32(item.ItemCode);
            viewModelData = new ItemViewModel() {
                Item = item
            };
            int x = itemRepository.SaveDetail(itemDetail);
            if(x > 0) {
                ModelState.Clear();
                ViewData["success_message"] = "New item detail successfully saved.";
            }
            return View(viewModelData);
        }

        public ActionResult EditDetail(int? itemID, int? detailID)
        {
            if (itemID == null || detailID == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                Item item = new Item();
                ItemDetail itemDetails = new ItemDetail();
                if (itemID != null)
                    item = itemRepository.GetItem(Convert.ToInt32(itemID));
                if (item != null)
                    itemDetails = itemRepository.GetItemDetails(Convert.ToInt32(detailID));
                else
                    item = new Item();

                viewModelData = new ItemViewModel {
                    Item = item,
                    ItemDetail = itemDetails
                };
                return View(viewModelData);
            }
        }

        [HttpPost]
        public ActionResult EditDetail(Item item, ItemDetail itemDetail)
        {
            try {
                itemDetail.ItemDetailCode = Convert.ToInt32(item.ItemCode);
                viewModelData = new ItemViewModel {
                    Item = item,
                    ItemDetail = itemDetail
                };

                if (itemDetail != null) {
                    if (ModelState.IsValid) {
                        itemRepository.UpdateDetail(itemDetail);
                        TempData["success_message"] = "Item detail successfully updated.";
                        return RedirectToAction("EditItem", new { id = item.ID});
                    }
                }
                else {
                    ViewData["error_message"] = "Item details cannot be empty. Please input item details then save.";
                }
                return View(viewModelData);
            }
            catch (Exception ex) {
                ViewData["error_message"] = "Found some error during updating of data. " + ex.Message.ToString();
                return View(viewModelData);
            }
        }

        public ActionResult DeleteItem (int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                Item item = new Item();
                item = itemRepository.GetItem(Convert.ToInt32(id));
                item = item == null ? new Item() : item;

                return View(item);
            }
        }

        [HttpPost]
        public ActionResult DeleteItem(Item item)
        {
            try {
                if (item.ID == 0) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else {
                    itemRepository.RemoveItem(item.ID);
                    TempData["success_message"] = "Item successfully removed.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex) {
                ViewData["error_message"] = "Found some error during removing of data. " + ex.Message.ToString();
                return View();
            }
        }

        public ActionResult DeleteDetail(int? itemID, int? detailID)
        {
            if (itemID == null || detailID == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                
                ItemDetail itemDetail = new ItemDetail();
                Item item = new Item();
                item.ID = Convert.ToInt32(itemID);
                itemDetail = itemRepository.GetItemDetails(Convert.ToInt32(detailID));

                ItemViewModel itemViewModel = new ItemViewModel() {
                    Item = item,
                    ItemDetail = itemDetail
                };

                return View(itemViewModel);
            }
        }

        [HttpPost]
        public ActionResult DeleteDetail(Item item, ItemDetail itemDetail)
        {
            try {
                if (itemDetail.ID == 0) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else {
                    itemRepository.RemoveDetail(itemDetail.ID);
                    TempData["success_message"] = "Item detail successfully removed.";
                    return RedirectToAction("EditItem", new { id = item.ID });
                }
            }
            catch (Exception ex) {
                ViewData["error_message"] = "Found some error during removing of data. " + ex.Message.ToString();
                return View();
            }
        }
    }
}