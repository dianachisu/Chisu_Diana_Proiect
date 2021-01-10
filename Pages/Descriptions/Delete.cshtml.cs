using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Chisu_Diana_Proiect.Data;
using Chisu_Diana_Proiect.Models;

namespace Chisu_Diana_Proiect.Pages.Descriptions
{
    public class DeleteModel : PageModel
    {
        private readonly Chisu_Diana_Proiect.Data.Chisu_Diana_ProiectContext _context;

        public DeleteModel(Chisu_Diana_Proiect.Data.Chisu_Diana_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Description Description { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Description = await _context.Description.FirstOrDefaultAsync(m => m.ID == id);

            if (Description == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Description = await _context.Description.FindAsync(id);

            if (Description != null)
            {
                _context.Description.Remove(Description);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
