using System.Collections;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.DTOs;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PresciptionsController : ControllerBase
{

    private readonly IDbRepository _dbRepository;
    
    public PresciptionsController(IDbRepository dbRepository)
    {
        _dbRepository = dbRepository;
    }

    
    /*
        *Końcówkę pozwalającą na wystawienie nowej recepty.
     
        Końcówka powinna przyjmować jako element żądania informacje
        o pacjencie, recepcie i informacje o lekarz wystawionych na
        danej recepcie.
        
        Jeśli pacjent przekazany w żądaniu nie istnieje, wstawiamy
        nowego pacjenta do tabeli Pacjent.
        
        Jeśli lek podany na recepcie nie istnieje, zwracamy błąd.
        
        Recepta może obejmować maksymalnie 10 leków. W innym
        wypadku zwracamy błąd.
        
        Musimy sprawdzić czy DueData>=Date
     * 
     */
    [HttpPost("patient/{patientId:int}")]
    public async Task<IActionResult> AddNewPresciptions(int patientId, RequestPrescriptionDto prescriptionDto)
    {
        if (patientId != prescriptionDto.Patient.IdPatients)
        {
            return BadRequest("Patient ID does not match!");
        }

        if (!await _dbRepository.DoesMedicamentsExists(prescriptionDto.Medicaments))
        {
            return BadRequest("Medicament doest not exists!");
        }

        if ( await _dbRepository.DoesPrescriptionHaveMoreThanTenMedicaments(prescriptionDto.Medicaments))
        {
            return BadRequest("Prescription has more than 10 medicaments!");
        }

        if (prescriptionDto.DueDate < prescriptionDto.Date)
        {
            return BadRequest("DueDate is earlier than Date on prescription!");
        }



        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            var patient = await _dbRepository.DoesPatientExistIfNotCreateNewOne(prescriptionDto.Patient);
            await _dbRepository.CreatePrescription(prescriptionDto, patient);
            
            scope.Complete();
        }

        return Created();
    }
}

