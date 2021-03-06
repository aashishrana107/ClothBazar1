﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothBazar.Entities;

namespace ClothBazar.Database
{
    public class CBContext : DbContext, IDisposable
    {
        public CBContext() : base("ClothBazarConnections")
        {
          
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Config> Configurations { get; set; }
    }
}
