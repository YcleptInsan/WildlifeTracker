using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WildlifeTracker.Models
{
    public class WildlifeTrackerContext : DbContext
    {
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<Sighting> Sighting { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WildlifeTracker;integrated security=True");
        }
    }
}
