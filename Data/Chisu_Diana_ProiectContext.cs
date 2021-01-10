using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chisu_Diana_Proiect.Models;

namespace Chisu_Diana_Proiect.Data
{
    public class Chisu_Diana_ProiectContext : DbContext
    {
        public Chisu_Diana_ProiectContext (DbContextOptions<Chisu_Diana_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Chisu_Diana_Proiect.Models.Plant> Plant { get; set; }

        public DbSet<Chisu_Diana_Proiect.Models.Shop> Shop { get; set; }

        public DbSet<Chisu_Diana_Proiect.Models.Category> Category { get; set; }

        public DbSet<Chisu_Diana_Proiect.Models.Description> Description { get; set; }
    }
}
