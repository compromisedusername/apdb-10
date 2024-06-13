namespace WebApplication3.DTOs;

public class ResponsePatientDto
{
    public IEnumerable<PrescriptionDto> Prescriptions { get; set; }
}

public class PrescriptionDto
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public IEnumerable<MedicamentDto> Medicaments { get; set; } 
    public DoctorDto Doctor { get; set; }
}


