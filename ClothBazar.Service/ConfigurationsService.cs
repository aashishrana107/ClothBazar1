using ClothBazar.Database;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Service
{
    public class ConfigurationsService
    {
        ////kyoki hum isse other classes hum iska use karge
        //public static ConfigurationsService Instance {
        //    get
        //    {
        //        if (instance == null) instance = new ConfigurationsService();
        //        return instance;
        //    }
        //}
        //private static ConfigurationsService instance { get; set; }
        //private ConfigurationsService()
        //{

        //}
        public Config GetConfig(string Key)
        {
            using (var context = new CBContext())
            {
               // return context.Configurations.Where(x => x.Key == Key).FirstOrDefault();
                return context.Configurations.Find(Key);
            }
        }
    }
}
