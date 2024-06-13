using Microsoft.AspNetCore.Mvc;
using WebApplication3.DTOs;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    
    private readonly IDbRepository _dbRepository;
    
    public PatientsController(IDbRepository dbRepository)
    {
        _dbRepository = dbRepository;
    }
    

    [HttpGet("{idPatient:int}/prescriptions")]
    public async Task<IActionResult> GetPatientsData(int  idPatient)
    {

        if (!await _dbRepository.DoesPatientExist(idPatient))
        {
            return BadRequest("Given patient: " + idPatient + ", doesnt exists!");
        }

        var res = await _dbRepository.GetPrescriptionsForPatient(idPatient);

        return Ok(res);
    }
    
}