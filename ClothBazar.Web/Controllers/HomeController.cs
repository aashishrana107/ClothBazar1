using ClothBazar.Service;
using ClothBazar.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class HomeController : Controller
    {
        //CatergoriesService catergoriesService = new CatergoriesService();
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.featuredCategories = CatergoriesService.Instance.GetFeaturedCategory();
           
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}