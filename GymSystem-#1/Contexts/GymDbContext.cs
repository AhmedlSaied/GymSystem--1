using GymSystem__1.Configuration;
using GymSystem__1.Models;
using Microsoft.EntityFrameworkCore;

namespace GymSystem__1.Contexts
{
    public class GymDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KAYN;Database=GymSystem1;trusted_connection=true;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Plan>(new PlanConfigurations());

        }
        public DbSet<Plan>Plans { get; set; } 
    }
}
