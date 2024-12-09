﻿using ActividadUT2.Domain.DTO;
using ActividadUT2.Domain.Entity;
using ActividadUT2.Domain.Enum;
using ActividadUT2.Domain.Generic;
using ActividadUT2.Domain.MapperProfile;
using ActividadUT2.Domain.Repository;
using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace ActividadUT2.Test.RepositoryTest;

[TestFixture]
public class CatRepositoryTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IEntityRepository<Guid, Cat>> _mockedCatRepository;

    public CatRepositoryTest()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CatProfile>();
        });
        _mapper = config.CreateMapper();
        _mockedCatRepository = new Mock<IEntityRepository<Guid, Cat>>();
    }

    [Test]
    public void Get_ThenReturnsCats()
    {
        // Arrange
        var catsDto = new List<CatDTO>
        {
            new(new Guid(), "Tako", 1, "Comun europeo", 5, HealthState.HEALTHY, new Guid()),
            new(new Guid(), "Yaki", 1, "Bombay", 5, HealthState.SICK, new Guid()),
            new(new Guid(), "Happy", 12, "Persa", 5, HealthState.HEALTHY, new Guid()),
            new(new Guid(), "Garfield", 5, "Maine Coon", 5, HealthState.SICK, new Guid()),
            new(new Guid(), "Meatball", 9, "Ragdoll", 5, HealthState.CRITIC, new Guid()),
        };
        var cats = _mapper.Map<List<Cat>>(catsDto);
        _mockedCatRepository.Setup(m => m.Get()).Returns(() => cats.AsQueryable());
        
        // Act
        var expectedCats = _mockedCatRepository.Object.Get();

        // Assert
        expectedCats.Should().BeEquivalentTo(cats.AsQueryable());
        expectedCats.Should().BeOfType<EnumerableQuery<Cat>>();
        expectedCats.Should().HaveCount(5);
    }

    [Test]
    public void Get_ValidId_ThenReturnsCat()
    {
        // Arrange
        var catDto = new CatDTO(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"), "Tako", 1, "Comun europeo", 5, HealthState.HEALTHY, new Guid("c785f08a-7d2c-4a8b-abb5-91d0e575fe8b"));
        var cat = _mapper.Map<Cat>(catDto);
        _mockedCatRepository.Setup(m => m.Get(cat.Id)).Returns(cat);
        
        // Act
        var expectedCat = _mockedCatRepository.Object.Get(cat.Id);
        
        // Assert
        expectedCat.Should().NotBeNull();
        expectedCat.Should().BeOfType<Cat>();
        expectedCat.Should().BeEquivalentTo(cat);
        expectedCat.Id.Should().Be(cat.Id);
    }
    
    [Test]
    public void Get_InvalidCatId_ThenReturnsNull()
    {
        // Arrange & Act
        _mockedCatRepository.Setup(m => m.Get(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"))).Returns(null as Cat);
        var receivedCat = _mockedCatRepository.Object.Get(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"));
        
        // Assert
        receivedCat.Should().BeNull();
    }

    [Test]
    public void Create_ValidCat_ThenReturnsCat()
    {
        // Arrange
        var catDto = new CatDTO(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"), "Tako", 1, "Comun europeo", 5, HealthState.HEALTHY, new Guid("c785f08a-7d2c-4a8b-abb5-91d0e575fe8b"));
        var cat = _mapper.Map<Cat>(catDto);
        _mockedCatRepository.Setup(m => m.Create(cat)).Returns(cat);
        
        // Act
        var expectedCat = _mockedCatRepository.Object.Create(cat);
        
        // Assert
        expectedCat.Should().NotBeNull();
        expectedCat.Should().BeOfType<Cat>();
        expectedCat.Should().BeEquivalentTo(cat);
        expectedCat.Id.Should().Be(cat.Id);
    }
    
    [Test]
    public void Create_InvalidCat_ThenReturnsNull()
    {
        // Arrange & Act
        _mockedCatRepository.Setup(m => m.Create(new Cat())).Returns(null as Cat);
        var receivedCat = _mockedCatRepository.Object.Create(new Cat());
        
        // Assert
        receivedCat.Should().BeNull();
    }

    [Test]
    public void Update_ValidCat_ThenReturnsCat()
    {
        // Arrange
        var catDto = new CatDTO(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"), "Tako", 1, "Comun europeo", 5, HealthState.HEALTHY, new Guid("c785f08a-7d2c-4a8b-abb5-91d0e575fe8b"));
        var cat = _mapper.Map<Cat>(catDto);
        _mockedCatRepository.Setup(m => m.Update(cat)).Returns(cat);
        
        // Act
        var expectedCat = _mockedCatRepository.Object.Update(cat);
        
        // Assert
        expectedCat.Should().NotBeNull();
        expectedCat.Should().BeOfType<Cat>();
        expectedCat.Should().BeEquivalentTo(cat);
        expectedCat.Id.Should().Be(cat.Id);
    }

    [Test] public void Update_InvalidCat_ThenReturnsNull()
    {
        // Arrange & Act
        _mockedCatRepository.Setup(m => m.Update(new Cat())).Returns(null as Cat);
        var receivedCat = _mockedCatRepository.Object.Update(new Cat());
        
        // Assert
        receivedCat.Should().BeNull();
    }

    [Test]
    public void Delete_ValidCat_ThenReturnsCat()
    {
        // Arrange
        var catDto = new CatDTO(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"), "Tako", 1, "Comun europeo", 5, HealthState.HEALTHY, new Guid("c785f08a-7d2c-4a8b-abb5-91d0e575fe8b"));
        var cat = _mapper.Map<Cat>(catDto);
        _mockedCatRepository.Setup(m => m.Delete(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"))).Returns(cat);
        
        // Act
        var expectedCat = _mockedCatRepository.Object.Delete(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"));
        
        // Assert
        expectedCat.Should().NotBeNull();
        expectedCat.Should().BeOfType<Cat>();
        expectedCat.Should().BeEquivalentTo(cat);
        expectedCat.Id.Should().Be(cat.Id);
    }

    [Test]
    public void Delete_InvalidCat_ThenReturnsNull()
    {
        // Arrange & Act
        _mockedCatRepository.Setup(m => m.Delete(new Guid())).Returns(null as Cat);
        var receivedCat = _mockedCatRepository.Object.Delete(new Guid());
        
        // Assert
        receivedCat.Should().BeNull();
    }
}