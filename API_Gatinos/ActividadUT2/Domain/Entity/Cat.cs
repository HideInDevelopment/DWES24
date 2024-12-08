using ActividadUT2.Domain.Enum;
using ActividadUT2.Domain.Generic;

namespace ActividadUT2.Domain.Entity;

#nullable disable

public class Cat : Entity<Guid>
{
    public Cat(){}
    public Cat(string name, int age, string race, int weight, HealthState healthState, Guid colonyId)
    {
        Name = name;
        Age = age;
        Race = race;
        Weight = weight;
        HealthState = healthState;
        ColonyId = colonyId;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Race  { get; set; }
    public int Weight { get; set; }
    public HealthState HealthState { get; set; }
    public Guid ColonyId { get; set; }
}