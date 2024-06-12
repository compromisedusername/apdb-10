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
    public DbSet<Medicament> Medicaments { get; set; } 
    public DbSet<Patient> Patients { get; set; } 
    public DbSet<Prescription> Prescriptions { get; set; } 
    public DbSet<PrescriptionMedicament> PrescriptionsMedicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
        {
            new Doctor()
            {
                IdDoctor = 1,
                FirstName = "Jan",
                LastName = "Kowalski"
            },
            new Doctor()
            {
                IdDoctor = 2,
                FirstName = "Anna",
                LastName = "Kowalska"
            }
        });
        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
        {
            new Medicament()
            {
                
            },
            new Medicament()
            {
                
            }
        });
    }
    
}