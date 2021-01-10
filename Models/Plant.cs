using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chisu_Diana_Proiect.Models
{
    public class Plant
    {
        public int ID { get; set; }

        [Display(Name = "Name")]
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Only use letters"),
          Required, StringLength(50, MinimumLength = 3)]

        public string Name { get; set; }
        [Range(1, 500)]
        [Column(TypeName = "decimal(6, 2)")]

        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; } 
        public int ShopID { get; set; }
        public Shop Shop { get; set; }
        public String Description { get; set; }

        public ICollection<PlantCategory> PlantCategories { get; set; }


    }
}
