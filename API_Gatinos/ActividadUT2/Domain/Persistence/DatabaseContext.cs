using ActividadUT2.Domain.Entity;
using ActividadUT2.Domain.Persistence.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ActividadUT2.Domain.Persistence;

public class DatabaseContext : DbContext
{
    public DbSet<Cat>? Cats { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatEntityConfiguration).Assembly);
    }

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    public override Task<int> SaveChangesAsync(
        bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = default
    )
    {
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}

public class OrderingContextDesignFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DatabaseContext>();

        var connectionString = configuration.GetConnectionString("DWES");

        builder.UseSqlServer(
            connectionString,
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", "DWES");
            }
        );

        return new DatabaseContext(builder.Options);
    }
}