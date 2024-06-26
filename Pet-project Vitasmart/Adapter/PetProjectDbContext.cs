using Microsoft.EntityFrameworkCore;
using Pet_project_Vitasmart.Models;

namespace Pet_project_Vitasmart.Adapter
{
    public class PetProjectDbContext : DbContext
    {
        public PetProjectDbContext(DbContextOptions<PetProjectDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<ICD> ICDs { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasKey(d => d.Id);
            modelBuilder.Entity<ICD>().HasKey(d => d.Code);
            modelBuilder.Entity<Visit>().HasKey(d => d.Id);
        }
    }
}
