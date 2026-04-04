using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIDemo1.Models;

namespace WebAPIDemo1.Data
{
    public class WebAPIDemo1Context : DbContext
    {
        public WebAPIDemo1Context (DbContextOptions<WebAPIDemo1Context> options)
            : base(options)
        {
        }

        public DbSet<WebAPIDemo1.Models.Laptop> Laptop { get; set; } = default!;
    }
}
