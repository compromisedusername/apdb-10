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
    [MaxLength(100)]
    public string IdPatient { get; set; }
    public string IdDoctor { get; set; }

    public ICollection<Medicament> Medicaments { get; set; } = new HashSet<Medicament>();
}