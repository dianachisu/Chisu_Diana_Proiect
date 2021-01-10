using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Chisu_Diana_Proiect.Data;
using Chisu_Diana_Proiect.Models;

namespace Chisu_Diana_Proiect.Pages.Shops
{
    public class IndexModel : PageModel
    {
        private readonly Chisu_Diana_Proiect.Data.Chisu_Diana_ProiectContext _context;

        public IndexModel(Chisu_Diana_Proiect.Data.Chisu_Diana_ProiectContext context)
        {
            _context = context;
        }

        public IList<Shop> Shop { get;set; }

        public async Task OnGetAsync()
        {
            Shop = await _context.Shop.ToListAsync();
        }
    }
}
