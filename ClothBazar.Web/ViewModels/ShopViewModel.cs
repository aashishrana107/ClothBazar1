﻿using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothBazar.Web.ViewModels
{
    public class CheckoutViewModel
    {
        public List<Product> CardProducts { get; set; }
        public List<int> CardProductIds { get; set; }
    }
}