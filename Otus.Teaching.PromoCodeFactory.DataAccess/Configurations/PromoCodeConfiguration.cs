using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Configurations;

public class PromoCodeConfiguration : IEntityTypeConfiguration<PromoCode>
{
    public void Configure(EntityTypeBuilder<PromoCode> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property<string>(x => x.Code).IsRequired().HasMaxLength(128);
        builder.Property<string>(x => x.PartnerName).IsRequired().HasMaxLength(128);
        builder.Property<string>(x => x.ServiceInfo).IsRequired().HasMaxLength(128);
        
        builder.HasOne(x => x.Preference)
            .WithOne()
            .HasForeignKey<Preference>(e => e.PromoCodeId)
            .IsRequired(); 

        builder.HasOne(x => x.PartnerManager)
            .WithOne()
            .HasForeignKey<Employee>(e => e.PromoCodeId)
            .IsRequired();
    }
}