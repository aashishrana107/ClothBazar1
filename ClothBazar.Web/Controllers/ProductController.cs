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
        ProductsService ProductsService = new ProductsService();
        // GET: Product
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult ProductTable(string search)
        {
            var products = ProductsService.GetProduct();
            //if(search==null)

            if(string.IsNullOrEmpty(search) == false)
            {
                //no ho to
              ///  products = products.Where(p =>p.Name !=null && p.Name.Contains(search)).ToList();
                products = products.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();

            }
            return PartialView(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CatergoriesService catergoriesService = new CatergoriesService();
            var category = catergoriesService.GetCategory();
            return PartialView(category);
        }

        [HttpPost]
        public ActionResult Create(CategoriesViewModels model)
        {
            CatergoriesService catergoriesService = new CatergoriesService();

            var newProduct =new Product();
            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Price = model.Price;
         //   newProduct.CategoryID = model.categoryID;
            newProduct.Category = catergoriesService.EditCategory(model.categoryID);
            ProductsService.SaveProduct(newProduct);
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var product = ProductsService.EditProduct(ID);
            return PartialView(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            ProductsService.EditProduct(product);
            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            ProductsService.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }
    }
}