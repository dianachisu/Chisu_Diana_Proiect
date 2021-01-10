using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chisu_Diana_Proiect.Models
{
    public class Description
    {
        public int ID { get; set; }
        public string Desc { get; set; }
        public string Name { get; set; }
        public ICollection<Plant> Plants { get; set; }
    }
}
