using ActividadUT2.Domain.Entity;
using ActividadUT2.Domain.Enum;
using ActividadUT2.Domain.Generic;
using ActividadUT2.Domain.Repository;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace ActividadUT2.Test.RepositoryTest;

[TestFixture]
public class CatRepositoryTest
{
    private readonly Mock<IEntityRepository<Guid, Cat>> _mockedCatRepository;

    public CatRepositoryTest()
    {
        _mockedCatRepository = new Mock<IEntityRepository<Guid, Cat>>();
    }
    
    public void SetUp()
    {
        _mockedCatRepository.Setup(m => m.Get()).Returns(new List<Cat>().AsQueryable());
        _mockedCatRepository.Setup(m => m.Get(It.IsAny<Guid>())).Returns(new Cat());
        _mockedCatRepository.Setup(m => m.Create(It.IsAny<Cat>())).Returns(new Cat());
        _mockedCatRepository.Setup(m => m.Update(It.IsAny<Cat>())).Returns(new Cat());
        _mockedCatRepository.Setup(m => m.Delete(It.IsAny<Guid>())).Returns(new Cat());
    }

    [Test]
    public void Get_AllCats_ThenReturnsCatQueryable()
    {
        //Arrange
        var cats = new List<Cat>
        {
            new("Tako", 1, "Comun europeo", 5, HealthState.HEALTHY, new Guid()),
            new("Yaki", 1, "Bombay", 5, HealthState.SICK, new Guid()),
            new("Happy", 12, "Persa", 5, HealthState.HEALTHY, new Guid()),
            new("Garfield", 5, "Maine Coon", 5, HealthState.SICK, new Guid()),
            new("Meatball", 9, "Ragdoll", 5, HealthState.CRITIC, new Guid()),
        };
        
        var queryableCats = cats.AsQueryable();
        _mockedCatRepository.Setup(m => m.Get()).Returns(queryableCats);
        
        //Act
        var expectedCats = _mockedCatRepository.Object.Get();

        //Assert
        expectedCats.Should().BeEquivalentTo(queryableCats);
        expectedCats.Should().BeOfType<EnumerableQuery<Cat>>();
        expectedCats.Should().HaveCount(5);
    }
}