using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chisu_Diana_Proiect.Models;

namespace Chisu_Diana_Proiect.Models
{
    public class Shop
    {
        public int ID { get; set; }
        public string ShopName { get; set; }
        public ICollection<Plant> Plants { get; set; }
    }
}
