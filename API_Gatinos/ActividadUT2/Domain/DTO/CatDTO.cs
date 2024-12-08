using ActividadUT2.Domain.Enum;

namespace ActividadUT2.Domain.DTO;

public class CatDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Race  { get; set; }
    public int Weight { get; set; }
    public HealthState HealthState { get; set; }
    public Guid ColonyId { get; set; }
}