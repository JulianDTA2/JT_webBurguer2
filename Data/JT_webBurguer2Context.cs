using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JT_webBurguer2.Models;

namespace JT_webBurguer2.Data
{
    public class JT_webBurguer2Context : DbContext
    {
        public JT_webBurguer2Context (DbContextOptions<JT_webBurguer2Context> options)
            : base(options)
        {
        }

        public DbSet<JT_webBurguer2.Models.Burguer> Burguer { get; set; } = default!;
        public DbSet<JT_webBurguer2.Models.Promos> Promos { get; set; } = default!;
    }
}
