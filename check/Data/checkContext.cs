using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using check.Models;

namespace check.Data
{
    public class checkContext : DbContext
    {
        public checkContext (DbContextOptions<checkContext> options)
            : base(options)
        {
        }

        public DbSet<check.Models.Employe> Employe { get; set; } = default!;
        public DbSet<check.Models.Tid> Tid { get; set; } = default!;
    }
}
