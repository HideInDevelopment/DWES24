using API_Gatinos.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Gatinos.Models.Persistence.EntityConfiguration;

public class ColoniaEntityConfiguration : IEntityTypeConfiguration<Colonia>
{
    public void Configure(EntityTypeBuilder<Colonia> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.Property(c => c.Nombre).HasMaxLength(75);
        builder.Property(c => c.Ubicacion).HasMaxLength(75);
        builder.Property(c => c.Telefono);
        builder.Property(c => c.Movil);
        builder.Property(c => c.Descripcion);
        builder.Property(c => c.Imagen);

        builder.HasMany(c => c.Gatos).WithOne().HasForeignKey(g => g.IdColonia);
        builder.HasMany(c => c.Colaboradores).WithMany(c => c.Colonias);

        builder.HasIndex(c => c.Id).HasDatabaseName("IX_Colonia_Id");
        builder.HasIndex(c => c.Nombre).HasDatabaseName("IX_Colonia_Nombre");
        builder.HasIndex(c => c.Ubicacion).HasDatabaseName("IX_Colonia_Ubicacion");

        builder
            .HasIndex(c => new { c.Nombre, c.Ubicacion })
            .HasDatabaseName("IX_Colonia_Nombre_Ubicacion");

        builder.ToTable("Colonias", "DWES");
    }
}
