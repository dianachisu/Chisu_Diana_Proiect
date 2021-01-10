using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chisu_Diana_Proiect.Models
{
    public class PlantCategory
    {
        public int ID { get; set; }
        public int PlantID { get; set; }
        public Plant Plant { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
