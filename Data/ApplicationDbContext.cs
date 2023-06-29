using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BaiThiNVA0025.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BaiThiNVA0025.Models.NVAcau3> NVAcau3 { get; set; } = default!;

        public DbSet<BaiThiNVA0025.Models.KeThua> KeThua { get; set; } = default!;
    }
