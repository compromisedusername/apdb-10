using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models;
[Table("prescriptions")]

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    
    [Timestamp]
    public string Date { get; set; }
    
    [Timestamp]
    public string DueDate { get; set; }
    
    /*[ForeignKey(nameof(IdPatient))]

    public string IdPatient { get; set; }
    
    [ForeignKey(nameof(IdDoctor))]
    public string IdDoctor { get; set; }*/
    
    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = new HashSet<PrescriptionMedicament>();
}