using WebApplication3.DTOs;
using WebApplication3.Models;

namespace WebApplication3.Services;

public interface IDbRepository
{
    Task<bool> DoesMedicamentsExists(List<MedicamentDto> prescriptionDtoMedicaments);
     Task <bool> DoesPrescriptionHaveMoreThanTenMedicaments(IEnumerable<MedicamentDto> medicaments);
    Task<Patient> DoesPatientExistIfNotCreateNewOne(PatientDto prescriptionDtoPatient);
    Task AddMedicament(Medicament medicament);
    Task CreatePrescription( RequestPrescriptionDto prescriptionDto, Patient patient);
    Task<bool> DoesPatientExist(int patientDtoIdPatient);
    Task<ResponsePatientDto> GetPrescriptionsForPatient(int idPatient);
    Task<List<MedicamentDto>> GetMedicaments();
}