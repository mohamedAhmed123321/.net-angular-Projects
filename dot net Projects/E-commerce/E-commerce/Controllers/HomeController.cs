using Bl.InterFaces;
using Domains.SpResult;
using Domains.Tables;
using Domains.ViewResult;
using E_commerce.Models;
using E_commerce.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
namespace E_commerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly  BusinessLayerInterFace<TbItem> _clsItem;
        public HomeController(BusinessLayerInterFace<TbItem> _clsItems, IWebHostEnvironment webHostEnvironment)
        {
            _clsItem = _clsItems;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            //string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", "Item");


            //string[] imageFiles = Directory.GetFiles(imageDirectory);
            //// Get all items from the database (assuming Item has an ID and ImagePath)
            //var items = _clsItem.GetAll();
            //for(int i=0;i<items.Count;i++ )
            //{
            //    string imageFileName = Path.GetFileName(imageFiles[i]);
            //    // Assign the image name (just the file name, without the full path)
            //    items[i].ImageName = imageFileName;

            //        // Save the updated item
            //        _clsItem.Save(items[i]);
                
            //}

            return View();
        }

    }
}
