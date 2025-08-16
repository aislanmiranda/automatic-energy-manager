using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Data.EntityConfig;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    // dotnet ef migrations add StartProjectAws --project ./Infrastructure/Infrastructure.csproj --startup-project ./Api/Api.csproj
    // dotnet ef database update --project ./Infrastructure/Infrastructure.csproj --startup-project ./Api/Api.csproj
    // dotnet ef migrations remove --force --project ./Infrastructure/Infrastructure.csproj --startup-project ./Api/Api.csproj

    public DbSet<User> Users => Set<User>();
    public DbSet<UserCustomer> UsersCustomers => Set<UserCustomer>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Equipament> Equipaments => Set<Equipament>();
    public DbSet<ScheduleTask> Tasks => Set<ScheduleTask>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserCustomerEntityConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerEntityConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EquipamentEntityConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskEntityConfig).Assembly);

        base.OnModelCreating(modelBuilder);
        //modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

    }
}