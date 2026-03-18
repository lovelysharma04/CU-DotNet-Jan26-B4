using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Day_60_WealthTrack.Models;

namespace Day_60_WealthTrack.Data
{
    public class Day_60_WealthTrackContext : DbContext
    {
        public Day_60_WealthTrackContext (DbContextOptions<Day_60_WealthTrackContext> options)
            : base(options)
        {
        }

        public DbSet<Day_60_WealthTrack.Models.Investment> Investment { get; set; } = default!;
    }
}
