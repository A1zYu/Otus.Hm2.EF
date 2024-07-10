using Microsoft.EntityFrameworkCore;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Configurations;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
        Database.EnsureDeleted(); // гарантируем, что бд удалена
        Database.EnsureCreated();
    }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<PromoCode> PromoCodes { get; set; }
    public DbSet<Preference> Preferences { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new PromoCodeConfiguration());
        modelBuilder.ApplyConfiguration(new PreferenceConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}