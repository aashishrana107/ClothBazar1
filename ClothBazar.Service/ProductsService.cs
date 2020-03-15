using ClothBazar.Database;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ClothBazar.Service
{
    public class ProductsService
    {
        #region Single ton
        //kyoki hum isse other classes hum iska use karge
        public static ProductsService ClassObject
        {
            get
            {
                if (privateInMemory == null) privateInMemory = new ProductsService();
                return privateInMemory;
            }
        }
        private static ProductsService privateInMemory { get; set; }
        #endregion end single ton

        private ProductsService()
        {

        }
        public Product EditProduct(int ID)
        {
            using (var context = new CBContext())
            {
                //  virtual key job kise product mil jaya ge tab ye us category ke information be le aaya ga
                return context.Products.Find(ID);
            }
        }

        // iss ka use Shop Controller me hoga
        public List<Product>  GetProduct(List<int> IDs)
        {
            using (var context = new CBContext())
            {
                return context.Products.Where(s => IDs.Contains(s.ID)).ToList();
            }
        }

        public List<Product> GetProduct(int pageNo)
        {
            int pageSize = 5;

            using (var context = new CBContext())
            {
                // return context.Products.OrderBy(s=>s.ID).Skip((pageNo-1)*pageSize).Take(pageSize).Include(x =>x.Category).ToList();
                return context.Products.Include(s => s.Category).ToList();
            }
        }

        public void SaveProduct(Product product)
        {
            using (var context = new CBContext())
            {
                context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;
                
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void EditProduct(Product product)
        {
            using (var context = new CBContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int ID)
        {
            using (var context = new CBContext())
            {
                var product = context.Products.Find(ID);
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
    }
}
