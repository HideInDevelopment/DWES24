using ActividadUT2.Domain.Enum;

namespace ActividadUT2.Domain.DTO;
#nullable disable
public class CatDTO
{
    public CatDTO(){}
    public CatDTO(Guid id, string name, int age, string race, int weight, HealthState healthState, Guid colonyId)
    {
        Id = id;
        Name = name;
        Age = age;
        Race = race;
        Weight = weight;
        HealthState = healthState;
        ColonyId = colonyId;
    }
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Race  { get; set; }
    public int Weight { get; set; }
    public HealthState HealthState { get; set; }
    public Guid ColonyId { get; set; }
}