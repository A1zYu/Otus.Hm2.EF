using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{ 
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property<string>(x => x.Email).IsRequired().HasMaxLength(128);
        builder.Property<string>(x => x.FirstName).IsRequired().HasMaxLength(128);
        builder.Property<string>(x => x.FullName).IsRequired().HasMaxLength(128);
        builder.Property<string>(x => x.LastName).IsRequired().HasMaxLength(128);
        
        builder.HasMany<PromoCode>(e => e.PromoCodes)
            .WithOne()
            .IsRequired();
        
    
    }
}