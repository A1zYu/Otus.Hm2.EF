using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property<string>("FirstName").IsRequired().HasMaxLength(50);
        builder.Property<string>("LastName").IsRequired().HasMaxLength(50);
        builder.Property<string>("Email").IsRequired().HasMaxLength(50);
        builder.HasOne(e => e.Role)
            .WithOne()
            .HasForeignKey<Role>(e => e.EmployeeId)
            .IsRequired();
        
    }
}