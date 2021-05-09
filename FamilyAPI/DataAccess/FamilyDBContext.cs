using Microsoft.EntityFrameworkCore;
using Models;

namespace FamilyAPI.DataAccess
{
    public class FamilyDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Adult> Adults { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\Constantin Mihail\RiderProjects\FamilyAPI\FamilyAPI\Family.db");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasKey(j => new {j.Salary, j.JobTitle});
        }

        
    }
}