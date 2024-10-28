using API_Gatinos.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Gatinos.Models.Persistence;

public class DatabaseContext : DbContext
{
    public DbSet<Colonia>? Colonias { get; set; }
    public DbSet<Gato>? Gatos { get; set; }
    public DbSet<Colaborador>? Colaboradores { get; set; }
}
