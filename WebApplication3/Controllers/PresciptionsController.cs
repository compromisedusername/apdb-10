using System.Collections;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PresciptionsController : ControllerBase
{
    private readonly IDbService _dbService;

    public PresciptionsController(IDbService dbService)
    {
        _dbService = dbService;
    }
    [HttpPost("{}")]
    public async Task<IActionResult> AddNewPresciptions()
}