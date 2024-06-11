using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WebApplication3.Models;

public class Patient
{
    [Key]
    public int IdPatients { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    [Timestamp]
    public string BirthDate { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
}