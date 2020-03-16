using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Entities
{
    public class Product : BaseEntity
    {
        // agar hum kise entity ke sath virtual keyword laga deya to entity framework samaj jaya ga ab mujha
        //iss Entity ke sath iss entity ka data be le kr aana hai
        public virtual Category Category { get; set; }


        
      //  public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
    }
}
