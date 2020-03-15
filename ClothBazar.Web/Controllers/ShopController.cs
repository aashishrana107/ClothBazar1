using ClothBazar.Service;
using ClothBazar.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    
    public class ShopController : Controller
    {
       // ProductsService productsService = new ProductsService();
        // GET: Shop
        public ActionResult Checkout()
        {
            CheckoutViewModel model = new CheckoutViewModel();

            //User ke browser se request aati hai
            var CardProductsCookie = Request.Cookies["CardProducts"];
            if(CardProductsCookie != null)
            {
                //var productIDs = CardProductsCookie.Value;

                //// uske id ko - ke base pr split karna hai

                //var ids = productIDs.Split('-');
                //List<int> pIDS = ids.Select(x => int.Parse(x)).ToList();
                model.CardProductIds = CardProductsCookie.Value.Split('-').Select(s => int.Parse(s)).ToList();
                model.CardProducts = ProductsService.ClassObject.GetProduct(model.CardProductIds);


           
            }
            return View(model);
        }
    }
}