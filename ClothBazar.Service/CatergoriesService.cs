using ClothBazar.Database;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Service
{
    public class CatergoriesService
    {
        public List<Category> GetCategory()
        {
            using (var context = new CBContext())
            {
                return context.Categories.ToList();
            }
        }
        public void SaveCategory(Category category)
        {
            using (var context = new CBContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
        public Category EditCategory(int ID)
        {
            using (var context = new CBContext())
            {
               // return context.Categories.Find(ID);
;                return context.Categories.Where(s => s.ID == ID).FirstOrDefault();
            }
        }

        public void EditCategory(Category category)
        {
            using (var context = new CBContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteCategory(Category category)
        {
            using (var context = new CBContext)
            {
                // context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                context.Categories.Remove(category);
            }
        }
    }
}
