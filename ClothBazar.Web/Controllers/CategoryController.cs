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
            var categories = catergoriesService.GetCategory();

            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category catergory)
        {
            catergoriesService.SaveCategory(catergory);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var category = catergoriesService.EditCategory(ID);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category catergory)
        {
            catergoriesService.EditCategory(catergory);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Category category)
        {
            catergoriesService.DeleteCategory(category.ID);
            return RedirectToAction("Index");
        }
        
    }
}