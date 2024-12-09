﻿using ActividadUT2.Domain.Enum;
using ActividadUT2.Domain.Generic;

namespace ActividadUT2.Domain.Entity;

#nullable disable

public class Cat : Entity<Guid>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Race  { get; set; }
    public int Weight { get; set; }
    public HealthState HealthState { get; set; }
    public Guid ColonyId { get; set; }
}