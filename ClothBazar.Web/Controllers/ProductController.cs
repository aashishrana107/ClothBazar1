using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothBazar.Entities;
using ClothBazar.Service;

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
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            ProductsService.SaveProduct(product);
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