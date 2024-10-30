using Bl.Enumorations;
using Bl.InterFaces;
using Domains.Tables;
using Domains.ViewResult;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace E_commerce.Controllers
{
    public class ItemController : Controller
    {
        #region PrivateFeilds
        private readonly ViewInterFace<VwItem> _itemView;
        private readonly BusinessLayerInterFace<TbItem> _clsItem;
        private readonly BusinessLayerInterFace<TbItemImage> _clsItemImage;
        #endregion
        #region ctx
        public ItemController(ViewInterFace<VwItem> _itemViews, BusinessLayerInterFace<TbItem> clsItem, BusinessLayerInterFace<TbItemImage> _clsItemImages)
        {
            _itemView = _itemViews;
            _clsItem = clsItem;
            _clsItemImage = _clsItemImages;
        }
        #endregion
        public IActionResult ItemDetails(int Id)
        {
            try
            {
                var item = _itemView.GetById(Id);
                var items = _clsItem.GetAll().Where(a=>a.CategoryId==item.CategoryId).Take(6).ToList();

                ViewBag.Recommended=items;

                List<TbItemImage> images = _clsItemImage.GetAll().Where(a => a.ItemId == Id).ToList();
                for (int i = 0; i < images.Count; i++)
                {
                    images[i].Item = null;
                }
                ViewBag.ItemImages = images;

                return View(item);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return View("~/");
            }
        }
        public IActionResult ItemList()
        {
            return View();
        }
    }
}
