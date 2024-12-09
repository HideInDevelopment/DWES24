using ActividadUT2.Controllers;
using ActividadUT2.Domain.DTO;
using ActividadUT2.Domain.Enum;
using ActividadUT2.Domain.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ActividadUT2.Test.ControllerTest;

[TestFixture]
public class CatControllerTest
{
    private readonly Mock<IEntityService<Guid, CatDTO>> _mockedCatService;
    private readonly CatController _catController;

    public CatControllerTest()
    {
        _mockedCatService = new Mock<IEntityService<Guid, CatDTO>>();
        _catController = new CatController(_mockedCatService.Object);
    }

    [Test]
    public void GetCats_ThenReturnHttpOKWithCats()
    {
        // Arrange
        var cats = new List<CatDTO>
        {
            new(new Guid(), "Tako", 1, "Comun europeo", 5, HealthState.HEALTHY, new Guid()),
            new(new Guid(), "Yaki", 1, "Bombay", 5, HealthState.SICK, new Guid()),
            new(new Guid(), "Happy", 12, "Persa", 5, HealthState.HEALTHY, new Guid()),
            new(new Guid(), "Garfield", 5, "Maine Coon", 5, HealthState.SICK, new Guid()),
            new(new Guid(), "Meatball", 9, "Ragdoll", 5, HealthState.CRITIC, new Guid()),
        };
        
        _mockedCatService.Setup(m => m.Get()).Returns(cats);
        
        // Act
        var result = _catController.GetCats();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }
    
    [Test]
    public void GetCats_ThenReturnHttpNotFound()
    {
        // Arrange
        _mockedCatService.Setup(m => m.Get()).Returns(new List<CatDTO>());
        
        // Act
        var result = _catController.GetCats();

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }

    [Test]
    public void GetCat_WithValidId_ThenReturnHttpOkWithCat()
    {
        // Arrange
        var cat = new CatDTO(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"), "Tako", 1, 
            "Comun europeo", 5, HealthState.HEALTHY, new Guid("c785f08a-7d2c-4a8b-abb5-91d0e575fe8b"));
        _mockedCatService.Setup(m => m.Get(cat.Id)).Returns(cat);
        
        // Act
        var result = _catController.GetCat(cat.Id);
        
        // Arrange
        result.Should().BeOfType<OkObjectResult>();
    }
    
    [Test]
    public void GetCat_WithInvalidId_ThenReturnHttpNotFound()
    {
        // Arrange
        _mockedCatService.Setup(m => m.Get(new Guid())).Returns(new CatDTO());
        
        // Act
        var result = _catController.GetCat(new Guid());

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }
    
    [Test]
    public void CreateCat_WithValidEntity_ThenReturnHttpOkWithCreatedCat()
    {
        // Arrange
        var cat = new CatDTO(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"), "Tako", 1, 
            "Comun europeo", 5, HealthState.HEALTHY, new Guid("c785f08a-7d2c-4a8b-abb5-91d0e575fe8b"));
        _mockedCatService.Setup(m => m.Create(cat)).Returns(cat);
        
        // Act
        var result = _catController.CreateCat(cat);
        
        // Arrange
        result.Should().BeOfType<OkObjectResult>();
    }
    
    [Test]
    public void CreateCat_WithInvalidEntity_ThenReturnHttpNotFound()
    {
        // Arrange
        _mockedCatService.Setup(m => m.Create(new CatDTO())).Returns(new CatDTO());
        
        // Act
        var result = _catController.CreateCat(new CatDTO());

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }
    
    [Test]
    public void UpdateCat_WithValidEntity_ThenReturnHttpOkWithUpdatedCat()
    {
        // Arrange
        var cat = new CatDTO(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"), "Tako", 1, 
            "Comun europeo", 5, HealthState.HEALTHY, new Guid("c785f08a-7d2c-4a8b-abb5-91d0e575fe8b"));
        _mockedCatService.Setup(m => m.Update(cat)).Returns(cat);
        
        // Act
        var result = _catController.UpdateCat(cat);
        
        // Arrange
        result.Should().BeOfType<OkObjectResult>();
    }
    
    [Test]
    public void UpdateCat_WithInvalidEntity_ThenReturnHttpNotFound()
    {
        // Arrange
        _mockedCatService.Setup(m => m.Update(new CatDTO())).Returns(new CatDTO());
        
        // Act
        var result = _catController.UpdateCat(new CatDTO());

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }
    
    [Test]
    public void DeleteCat_WithValidId_ThenReturnHttpOkWithDeletedCat()
    {
        // Arrange
        var cat = new CatDTO(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"), "Tako", 1, 
            "Comun europeo", 5, HealthState.HEALTHY, new Guid("c785f08a-7d2c-4a8b-abb5-91d0e575fe8b"));
        _mockedCatService.Setup(m => m.Delete(cat.Id)).Returns(cat);
        
        // Act
        var result = _catController.DeleteCat(cat.Id);
        
        // Arrange
        result.Should().BeOfType<OkObjectResult>();
    }
    
    [Test]
    public void CreateCat_WithInvalidId_ThenReturnHttpNotFound()
    {
        // Arrange
        _mockedCatService.Setup(m => m.Delete(new Guid())).Returns(new CatDTO());
        
        // Act
        var result = _catController.DeleteCat(new Guid());

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }
}