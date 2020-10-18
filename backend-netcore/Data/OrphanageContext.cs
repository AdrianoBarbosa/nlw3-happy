using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Happy.Models;

    public class OrphanageContext : DbContext
    {
        public OrphanageContext (DbContextOptions<OrphanageContext> options)
            : base(options)
        {
        }

        public DbSet<Happy.Models.Orphanage> Orphanage { get; set; }
    }
