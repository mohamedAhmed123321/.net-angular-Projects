using Bl.Classes;
using Bl.Enumorations;
using Bl.InterFaces;
using Domains.Tables;
using E_commerce.Models;
using E_commerce.Utlities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

namespace E_commerce.Areas.admin.Controllers
{
    public class ItemController : BaseController
    {
        #region privateFields
        private readonly BusinessLayerInterFace<TbItem> _clsItem;
        private readonly BusinessLayerInterFace<TbO> _clsItemOs;
        private readonly BusinessLayerInterFace<TbItemType> _clsItemType;
        private readonly BusinessLayerInterFace<TbCategory> _clsCategory;
        private readonly BusinessLayerInterFace<TbItemImage> _clsItemImage;
        #endregion
        #region ctor
        public ItemController(BusinessLayerInterFace<TbItemImage> _clsItemImages, BusinessLayerInterFace<TbCategory> _clsCategorys, BusinessLayerInterFace<TbItem> _clsItems, BusinessLayerInterFace<TbO> _clsItemOss, BusinessLayerInterFace<TbItemType> _clsItemTypes)
        {
            _clsItem = _clsItems;
            _clsItemOs = _clsItemOss;
            _clsItemType = _clsItemTypes;
            _clsCategory = _clsCategorys;
            _clsItemImage = _clsItemImages;
        }
        #endregion
        #region Helper Methods
        private void LoadTempDataMessages()
        {
            if (TempData.ContainsKey("Success"))
            {
                ViewBag.Success = TempData["Success"].ToString();
            }
            if (TempData.ContainsKey("Failed"))
            {
                ViewBag.Failed = TempData["Failed"].ToString();
            }
        }

        private void LogError(Exception ex)
        {
            Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
        }
        #endregion
        #region Actions
        public IActionResult List()
        {
            try
            {
                LoadTempDataMessages();
                var colums = _clsItem.GetAll();
                return View(colums);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return RedirectToAction("Error", "Home");
            }

        }
        public IActionResult Edit(int? Id)
        {
            try
            {
                TbItem item = new TbItem();
                if (Id != null)
                {
                    item = _clsItem.GetById(Convert.ToInt32(Id));
                   List<TbItemImage> images = _clsItemImage.GetAll().Where(a => a.ItemId == item.ItemId).ToList() ;
                    for(int i = 0; i < images.Count; i++)
                    {
                        images[i].Item = null;
                    }
                    ViewBag.images = images;
                }
                ViewBag.itemtype = _clsItemType.GetAll();
                ViewBag.itemOs =_clsItemOs.GetAll();
                ViewBag.category = _clsCategory.GetAll();

                return View(item);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return RedirectToAction("Error", "Home");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TbItem Item, string myStringImages)
        {
            try
            {
                ModelState.Remove("CreatedBy");
                if (!ModelState.IsValid)
                    return View("Edit", Item);

                var images = JsonConvert.DeserializeObject<List<MediaModel>>(myStringImages);
                bool isImage;

              string image=  Helper.UploadImageAndCheck(images.Where(a => a.isDefualt == true).FirstOrDefault().File, Item.ImageName, "Item",out isImage);
     
                if (!isImage)
                {
                    ModelState.AddModelError("ImageName", image);
                    return View("Edit", Item);
                }
                Item.ImageName = image;

  
                bool result = _clsItem.Save(Item);
                TempData[result ? "Success" : "Failed"] = result ? "Saved successfully" : "Save operation failed";

                images.Remove(images.Where(a => a.isDefualt == true).FirstOrDefault());
                TbItemImage itemImage;

                foreach (var img in images)
                {
                    if (img.Id == default(int))
                        itemImage = new TbItemImage();
                    else
                        itemImage= _clsItemImage.GetById(img.Id);
                    itemImage.ItemId = Item.ItemId;
                    itemImage.ImageId = img.Id;
                    itemImage.Item = Item;
                    itemImage.ImageName = Helper.UploadImage(img.File,"Item",out isImage);
                    if(isImage)
                        _clsItemImage.Save(itemImage);
                }

                return result ? RedirectToAction("List") : View("Edit", Item);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }
        public IActionResult Delete(int Id)
        {
            try
            {
                bool result = _clsItem.ChangeState(Id, EntityStateEnum.Deleted);
                TempData[result ? "Success" : "Failed"] = result ? "Deleted successfully" : "Delete operation failed.";
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }
        public bool DeleteItemImage(int Id)
        {
            try
            {
                bool result = _clsItemImage.ChangeState(Id, EntityStateEnum.Deleted);
                TempData[result ? "Success" : "Failed"] = result ? "Deleted successfully" : "Delete operation failed.";
                return true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }
        #endregion
    }
    
}
