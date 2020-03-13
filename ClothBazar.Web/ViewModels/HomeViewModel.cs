using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothBazar.Web.ViewModels
{
    //ya humna home pr data send krna le leya banaya hai
    // product and category
    public class HomeViewModel
    {
        public List<Category> featuredCategories { get; set; }
        public List<Product> featuredProducts { get; set; }
    }
}