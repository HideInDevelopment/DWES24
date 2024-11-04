using API_Gatinos.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Gatinos.Models.Persistence.EntityConfiguration;

public class ColaboradorEntityConfiguration : IEntityTypeConfiguration<Colaborador>
{
    public void Configure(EntityTypeBuilder<Colaborador> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.Property(c => c.Nombre).HasMaxLength(75);
        builder.Property(c => c.Edad);
        builder.Property(c => c.Telefono);
        builder.Property(c => c.Email).HasMaxLength(100);

        builder.HasIndex(c => c.Id).HasDatabaseName("IX_Colaborador_Id");
        builder.HasIndex(c => c.Email).HasDatabaseName("IX_Colaborador_Email");
        builder.HasIndex(c => c.Telefono).HasDatabaseName("IX_Colaborador_Telefono");

        builder
            .HasIndex(c => new { c.Nombre, c.Telefono })
            .HasDatabaseName("IX_Colaborador_Nombre_Telefono");

        builder.ToTable("Colaboradores", "DWES");
    }
}
