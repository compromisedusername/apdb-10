using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApplication3.Controllers;
using WebApplication3.DTOs;
using WebApplication3.Services;

namespace TestProject1;

public class WebApiTests
{

    private readonly Mock<IDbRepository> _mockMedicamentService;
    private readonly MedicamentController _controller;

    public WebApiTests()
    {
        _mockMedicamentService = new Mock<IDbRepository>();
        _controller = new MedicamentController(_mockMedicamentService.Object);
    }

    [Fact]
    public async Task GetMedicaments_ReturnsOkResult_WithListOfMedicaments()
    {
        // Arrange
        var mockMedicaments = new List<MedicamentDto>
        {
            new MedicamentDto { IdMedicament = 1, Description = "Medicament1", Details = "Details1", Dose = 1},
            new MedicamentDto { IdMedicament = 2, Description = "Medicament2",Details = "Details2", Dose = 2 }
        };

        _mockMedicamentService.Setup(service => service.GetMedicaments())
            .ReturnsAsync(mockMedicaments);

        // Act
        var result = await _controller.GetMedicaments();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<MedicamentDto>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    [Fact]
    public async Task GetPatientsData_ReturnsOkResult_WithListOfPrescriptionsMedicamentsAndDoctor()
    {
        
        var patients = new List<MedicamentDto>
        {
            new MedicamentDto { IdMedicament = 1, Description = "Medicament1", Details = "Details1", Dose = 1},
            new MedicamentDto { IdMedicament = 2, Description = "Medicament2",Details = "Details2", Dose = 2 }
        };

        _mockMedicamentService.Setup(service => service.GetMedicaments())
            .ReturnsAsync(mockMedicaments);

        // Act
        var result = await _controller.GetMedicaments();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<MedicamentDto>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);

    }

}
