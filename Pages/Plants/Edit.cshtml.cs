using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chisu_Diana_Proiect.Data;
using Chisu_Diana_Proiect.Models;

namespace Chisu_Diana_Proiect.Pages.Plants
{
    public class EditModel : PlantCategoriesPageModel
    {
        private readonly Chisu_Diana_Proiect.Data.Chisu_Diana_ProiectContext _context;

        public EditModel(Chisu_Diana_Proiect.Data.Chisu_Diana_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Plant Plant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Plant = await _context.Plant
             .Include(b => b.Shop)
             .Include(b => b.PlantCategories).ThenInclude(b => b.Category)
             .AsNoTracking()
             .FirstOrDefaultAsync(m => m.ID == id);


            if (Plant == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Plant);

            ViewData["ShopID"] = new SelectList(_context.Set<Shop>(), "ID", "ShopName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var PlantToUpdate = await _context.Plant
            .Include(i => i.Shop)
            .Include(i => i.PlantCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (PlantToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Plant>(
            PlantToUpdate,
            "Plant",
            i => i.Name,
            i => i.Price, i => i.OrderDate, i => i.Shop, i => i.PlantCategories, i => i.Description))
            {
                UpdatePlantCategories(_context, selectedCategories, PlantToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdatePlantCategories pentru a aplica informatiile din checkboxuri la entitatea Plants care
            //este editata
            UpdatePlantCategories(_context, selectedCategories, PlantToUpdate);
            PopulateAssignedCategoryData(_context, PlantToUpdate);
            return Page();
        }
    }
}
