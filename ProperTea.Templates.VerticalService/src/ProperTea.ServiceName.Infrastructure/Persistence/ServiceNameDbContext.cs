using Microsoft.EntityFrameworkCore;
using ProperTea.ServiceName.Domain.AggregateRootNames;

namespace ProperTea.ServiceName.Infrastructure.Persistence;

public class ServiceNameDbContext : DbContext
{
    public ServiceNameDbContext()
    {
    }

    public ServiceNameDbContext(DbContextOptions<ServiceNameDbContext> options)
        : base(options)
    {
    }

    public DbSet<AggregateRootName> AggregateRootNames { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ServiceNameDbContext).Assembly);
    }
}