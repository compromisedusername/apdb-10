using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.DTOs;
using WebApplication3.Models;

namespace WebApplication3.Services;

public class DbRepository : IDbRepository
{
    private readonly ApplicationContext _context;

    public DbRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<bool> DoesMedicamentsExists(List<MedicamentDto> prescriptionDtoMedicaments)
    {
        foreach (var medicament in prescriptionDtoMedicaments)
        {
            if (await _context.Medicaments.FindAsync(medicament.IdMedicament) is null)
            {
                return false;
            }
        }

        return true;
    }

    public async Task<bool> DoesPrescriptionHaveMoreThanTenMedicaments(IEnumerable<MedicamentDto> medicaments)
    {
        return medicaments.Count() > 10;
    }

    public async Task<Patient> DoesPatientExistIfNotCreateNewOne(PatientDto prescriptionDtoPatient)
    {
        var patient =
            await _context.Patients.FirstOrDefaultAsync(e => e.IdPatients == prescriptionDtoPatient.IdPatients);
        if (patient is null)
        {
            patient = new Patient()
            {
                FirstName = prescriptionDtoPatient.FirstName,
                LastName = prescriptionDtoPatient.LastName,
                BirthDate = prescriptionDtoPatient.BirthDate
            };

            await _context.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        return patient;
    }

    public async Task AddMedicament(Medicament medicament)
    {
        await _context.AddAsync(medicament);
        await _context.SaveChangesAsync();
    }

    public async Task CreatePrescription(RequestPrescriptionDto prescriptionDto, Patient patient)
    {

        var prescription = new Prescription()
        {
            Date = prescriptionDto.Date,
            DueDate = prescriptionDto.DueDate,
            IdDoctor = prescriptionDto.IdDoctor,
            Patient = patient,
        };


        var medicamentsPrescription = new List<PrescriptionMedicament>();
        foreach (var medicament in prescriptionDto.Medicaments)
        {
            medicamentsPrescription.Add(
                new PrescriptionMedicament()
                {
                    Details = medicament.Details,
                    Dose = medicament.Dose,
                    IdMedicament = medicament.IdMedicament,
                    Prescription = prescription
                }
            );
        }


        await _context.AddAsync(prescription);
        await _context.AddRangeAsync(medicamentsPrescription);

        await _context.SaveChangesAsync();
    }

    public async Task<bool> DoesPatientExist(int patientDtoIdPatient)
    {
        return await _context.Patients.AnyAsync(e => e.IdPatients == patientDtoIdPatient);
    }

    public async Task<ResponsePatientDto> GetPrescriptionsForPatient(int idPatient)
    {


        var prescriptions = await _context.Prescriptions
            .Include(e => e.Doctor)
            .Include(e => e.Patient)
            .Include(e => e.PrescriptionMedicaments)
            .ThenInclude(e => e.Medicament)
            .Where(e => e.IdPatient == idPatient)
            .ToListAsync();

        var responsePatientDto = new ResponsePatientDto
        {
            Prescriptions =  prescriptions.Select(e => new PrescriptionDto
            {
                Date = e.Date,
                Doctor = new DoctorDto
                {
                    Email = e.Doctor.Email,
                    FirstName = e.Doctor.FirstName,
                    LastName = e.Doctor.LastName,
                    IdDoctor = e.Doctor.IdDoctor
                },
                DueDate = e.DueDate,
                IdPrescription = e.IdPrescription,
                Medicaments = e.PrescriptionMedicaments.Select(ee => new MedicamentDto
                {
                    Description = ee.Medicament.Description,
                    Details = ee.Details,
                    Dose = ee.Dose,
                    IdMedicament = ee.IdMedicament
                })
            })
        };

        return responsePatientDto;
    }

    public async Task<List<MedicamentDto>> GetMedicaments()
    {
        return await _context.Medicaments.Select(e => new MedicamentDto()
        {
            IdMedicament = e.IdMedicament,
            Description = e.Description,
            Details = e.Detail,
            Dose = e.Dose
        }).ToListAsync();
    }
}