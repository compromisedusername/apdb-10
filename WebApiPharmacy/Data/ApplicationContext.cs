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
                Email = "email@.com",
                FirstName = "firstname",
                IdDoctor = 1,
                LastName = "lastname",
            }
        });
        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
        {
           new Medicament()
           {
               Description = "description",
               IdMedicament = 1,
               Detail = "detial",
               Dose = 1
           }
        }); modelBuilder.Entity<Patient>().HasData(new List<Patient>
        {
           new Patient()
           {
               BirthDate = DateTime.Now,
               FirstName = "firstname",
               IdPatients = 1,
               LastName = "lastname"
           }
        }); modelBuilder.Entity<Prescription>().HasData(new List<Prescription>
        {
           new Prescription()
           {
               Date = DateTime.Now,
               DueDate = DateTime.MaxValue,
               IdDoctor = 1,
               IdPatient = 1,
               IdPrescription = 1
           }
        }); modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>
        {
         new PrescriptionMedicament()
         {
             Details = "details",
             Dose = 1,
             IdMedicament = 1,
             IdPrescription = 1
         }  
        });
    }
    
}