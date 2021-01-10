using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Chisu_Diana_Proiect.Data;
using Chisu_Diana_Proiect.Models;

namespace Chisu_Diana_Proiect.Pages.Plants
{
    public class IndexModel : PageModel
    {
        private readonly Chisu_Diana_Proiect.Data.Chisu_Diana_ProiectContext _context;

        public IndexModel(Chisu_Diana_Proiect.Data.Chisu_Diana_ProiectContext context)
        {
            _context = context;
        }

        public IList<Plant> Plant { get;set; }
        public PlantData PlantD { get; set; }
        public int PlantID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            PlantD = new PlantData();

            PlantD.Plants = await _context.Plant
            .Include(b => b.Shop)
            .Include(b => b.PlantCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                PlantID = id.Value;
                Plant Plant = PlantD.Plants
                .Where(i => i.ID == id.Value).Single();
                PlantD.Categories = Plant.PlantCategories.Select(s => s.Category);
            }
        }
       
    }
}
