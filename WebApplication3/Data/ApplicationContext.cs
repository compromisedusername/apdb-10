using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data;

public class ApplicationContext : DbContext
{
    protected ApplicationContext()
    { }

    public ApplicationContext(DbContextOptions options) : base(options)
    { }
    
    public DbSet<Doctor> Doctors { get; set; } 
    public DbSet<Doctor> Medicaments { get; set; } 
    public DbSet<Doctor> Patients { get; set; } 
    public DbSet<Doctor> Prescriptions { get; set; } 
    public DbSet<Doctor> PrescriptionsMedicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
        {
            new() { }
        });
        //todo... 

    }
    
}