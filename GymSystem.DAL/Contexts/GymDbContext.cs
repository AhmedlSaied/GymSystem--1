using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GymSystem.DAL.Configuration;
using GymSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymSystem.DAL.Contexts
{
    public class GymDbContext:DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=KAYN;Database=GymSystem1;trusted_connection
        //    =true;TrustServerCertificate=True");
        //}

        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        public DbSet<Plan> Plans { get; set; }
    }
}
