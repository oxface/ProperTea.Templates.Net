using Microsoft.EntityFrameworkCore;

namespace ProperTea.ServiceName.Persistence;

public class ServiceNameDbContext : DbContext
{
    public ServiceNameDbContext()
    {
    }

    public ServiceNameDbContext(DbContextOptions<ServiceNameDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ServiceNameDbContext).Assembly);
    }
}