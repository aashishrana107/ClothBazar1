using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClothBazar.Entities;

namespace ClothBazar.Web.ViewModels
{
    public class ProductSerachViewModel
    {
        public List<Product> products { get; set; }
        public int pageNo { get;set; }
    }
}