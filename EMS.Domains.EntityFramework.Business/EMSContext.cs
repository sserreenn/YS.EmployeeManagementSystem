using EMS.Domains.EntityFramework.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.Domains.EntityFramework.Business
{
    public class EMSContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-NI5JV8G\\SEREN0960;database=EMS; integrated security=true;TrustServerCertificate=True");
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Checkin> Checkins { get; set; }
    }
}