using Microsoft.EntityFrameworkCore;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<PromoCode> PromoCodes { get; set; }
    public DbSet<Preference> Preferences { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasKey(x => x.Id);
        modelBuilder.Entity<Role>().Property<string>(x => x.Name).IsRequired().HasMaxLength(128);
        modelBuilder.Entity<Role>().Property<string>(x => x.Description).IsRequired().HasMaxLength(256);

        modelBuilder.Entity<Employee>().HasKey(k => k.Id);
        modelBuilder.Entity<Employee>().Property<string>("FirstName").IsRequired().HasMaxLength(50);
        modelBuilder.Entity<Employee>().Property<string>("LastName").IsRequired().HasMaxLength(50);
        modelBuilder.Entity<Employee>().Property<string>("Email").IsRequired().HasMaxLength(50);
        modelBuilder.Entity<Employee>().HasOne(e => e.Role)
            .WithOne()
            .HasForeignKey<Role>(e => e.EmployeeId)
            .IsRequired();      
    }
}