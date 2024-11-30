using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JT_webBurguer2.Models;

namespace WebApiJT.Data
{
    public class WebApiJTContext : DbContext
    {
        public WebApiJTContext (DbContextOptions<WebApiJTContext> options)
            : base(options)
        {
        }

        public DbSet<JT_webBurguer2.Models.Burguer> Burguer { get; set; } = default!;
    }
}
