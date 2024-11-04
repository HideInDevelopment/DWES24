using API_Gatinos.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Gatinos.Models.Persistence.EntityConfiguration;

public class GatoEntityConfiguration : IEntityTypeConfiguration<Gato>
{
    public void Configure(EntityTypeBuilder<Gato> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).ValueGeneratedOnAdd();

        builder.Property(g => g.Nombre).HasMaxLength(75);
        builder.Property(g => g.Edad);
        builder.Property(g => g.Raza).HasMaxLength(50);
        builder.Property(g => g.Peso);
        builder.Property(g => g.EstadoSalud);
        builder.Property(g => g.IdColonia);

        builder.HasIndex(g => g.Id).HasDatabaseName("IX_Gato_Id");
        builder.HasIndex(g => g.Nombre).HasDatabaseName("IX_Gato_Nombre");
        builder.HasIndex(g => g.Raza).HasDatabaseName("IX_Gato_Raza");
        builder
            .HasIndex(g => new { g.Raza, g.IdColonia })
            .HasDatabaseName("IX_Gato_Raza_IdColonia");
        builder
            .HasIndex(g => new { g.Nombre, g.IdColonia })
            .HasDatabaseName("IX_Gato_Raza_IdColonia");

        builder.ToTable("Gatos", "DWES");
    }
}
