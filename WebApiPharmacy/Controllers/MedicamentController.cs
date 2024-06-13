using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WebApplication3.DTOs;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers;


[ApiController]
[Route("api/[controller]")]
public class MedicamentController : ControllerBase
{

    private readonly IDbRepository _dbRepository;
    public MedicamentController(IDbRepository dbRepository)
    {
        _dbRepository = dbRepository;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddMedicament( MedicamentDto medicamentDto)
    {
        var medicament = new Medicament()
        {
            IdMedicament = medicamentDto.IdMedicament,
            Description = medicamentDto.Description,
            Detail = medicamentDto.Details,
            Dose = medicamentDto.Dose
        };
         await _dbRepository.AddMedicament(medicament);
         return Ok();
    }


    public async Task<IActionResult> GetMedicaments()
    {
        return Ok(await _dbRepository.GetMedicaments());
    }
}