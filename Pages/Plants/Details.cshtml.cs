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
    public class DetailsModel : PageModel
    {
        private readonly Chisu_Diana_Proiect.Data.Chisu_Diana_ProiectContext _context;

        public DetailsModel(Chisu_Diana_Proiect.Data.Chisu_Diana_ProiectContext context)
        {
            _context = context;
        }

        public Plant Plant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Plant = await _context.Plant.FirstOrDefaultAsync(m => m.ID == id);

            if (Plant == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
