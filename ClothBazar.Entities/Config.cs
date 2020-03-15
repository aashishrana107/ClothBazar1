using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Entities
{
    public class Config
    {
        // it is use for facebook tweeter link
        //key he yaha pr primary key hoge kyoki key humesa unique hoge
        [Key]
        public string Key { get; set; }
        public string value { get; set; }
    }
}
