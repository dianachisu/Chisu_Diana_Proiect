using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Chisu_Diana_Proiect.Data;
using Chisu_Diana_Proiect.Models;

namespace Chisu_Diana_Proiect.Pages.Categorie
{
    public class IndexModel : PageModel
    {
        private readonly Chisu_Diana_Proiect.Data.Chisu_Diana_ProiectContext _context;

        public IndexModel(Chisu_Diana_Proiect.Data.Chisu_Diana_ProiectContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
