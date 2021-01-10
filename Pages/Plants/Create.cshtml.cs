using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Chisu_Diana_Proiect.Data;
using Chisu_Diana_Proiect.Models;

namespace Chisu_Diana_Proiect.Pages.Plants
{
    public class CreateModel : PlantCategoriesPageModel
    {
        private readonly Chisu_Diana_Proiect.Data.Chisu_Diana_ProiectContext _context;

        public CreateModel(Chisu_Diana_Proiect.Data.Chisu_Diana_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            {
                ViewData["ShopID"] = new SelectList(_context.Set<Shop>(), "ID", "ShopName");
                var plant = new Plant();
                plant.PlantCategories = new List<PlantCategory>();
                PopulateAssignedCategoryData(_context, plant);
                return Page();
            }
        }

        [BindProperty]
        public Plant Plant { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newPlant = new Plant();
            if (selectedCategories != null)
            {
                newPlant.PlantCategories = new List<PlantCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new PlantCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newPlant.PlantCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Plant>(
            newPlant,
            "Plant",
            i => i.Name,
            i => i.Price, i => i.OrderDate, i => i.ShopID, i => i.PlantCategories, i => i.Description))
            {
                _context.Plant.Add(newPlant);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newPlant);
            return Page();
        }
    }
}