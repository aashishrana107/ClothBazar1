using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothBazar.Entities;
using ClothBazar.Service;
using ClothBazar.Web.ViewModels;

namespace ClothBazar.Web.Controllers
{
    public class ProductController : Controller
    {
       // ProductsService ProductsService = new ProductsService();
        // GET: Product
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult ProductTable(string search, int? pageNo)
        
            {
            ProductSerachViewModel model = new ProductSerachViewModel();

            model.pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            //if(pageNo.HasValue)
            //{
            //    if(pageNo.Value>0)
            //    {
            //        model.pageNo = pageNo.Value;
            //    }
            //    else
            //    {
            //        model.pageNo = 1;
            //    }
            //}
            //else
            //{
            //    model.pageNo = 1;
            //}
            



            model.products = ProductsService.ClassObject.GetProduct(model.pageNo);
            //if(search==null)

            if(string.IsNullOrEmpty(search) == false)
            {
                //no ho to
              ///  products = products.Where(p =>p.Name !=null && p.Name.Contains(search)).ToList();
                model.products = model.products.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();

            }
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //CatergoriesService catergoriesService = new CatergoriesService();
            var category = CatergoriesService.Instance.GetCategory();
            return PartialView(category);
        }

        [HttpPost]
        public ActionResult Create(CategoriesViewModels model)
        {
           // CatergoriesService catergoriesService = new CatergoriesService();

            var newProduct =new Product();
            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Price = model.Price;
         //   newProduct.CategoryID = model.categoryID;
            newProduct.Category = CatergoriesService.Instance.EditCategory(model.categoryID);
            ProductsService.ClassObject.SaveProduct(newProduct);
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var product = ProductsService.ClassObject.EditProduct(ID);
            return PartialView(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            ProductsService.ClassObject.EditProduct(product);
            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            ProductsService.ClassObject.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }
    }
}