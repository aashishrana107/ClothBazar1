using ClothBazar.Entities;
using ClothBazar.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class CategoryController : Controller
    {

        CatergoriesService catergoriesService = new CatergoriesService();

        [HttpGet]
        public ActionResult Index()
        {
           

            return View();
        }

        public ActionResult CategoryTable(string search)
        {
            var categories = catergoriesService.GetCategory();
            if(string.IsNullOrEmpty(search) == false)
            {
                categories = categories.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            return PartialView(categories);
            
        }



        [HttpGet]
        public ActionResult Create()
        {
           
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(Category catergory)
        {
            catergoriesService.SaveCategory(catergory);
            return RedirectToAction("CategoryTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var category = catergoriesService.EditCategory(ID);
            return PartialView(category);
        }
        [HttpPost]
        public ActionResult Edit(Category catergory)
        {
            catergoriesService.EditCategory(catergory);
            return RedirectToAction("CategoryTable");
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            catergoriesService.DeleteCategory(ID);
            return RedirectToAction("CategoryTable");
        }
        
    }
}