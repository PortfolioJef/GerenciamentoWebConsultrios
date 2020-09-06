using Microsoft.EntityFrameworkCore;
using SymSaudeApi.Entities;
using SymSaudeApi.Models;

namespace SymSaudeApi.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Clinic> clinics { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<DoctorClinic> doctorClinics { get; set; }

    }
}