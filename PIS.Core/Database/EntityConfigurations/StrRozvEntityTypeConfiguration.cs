using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIS.Core.Database.Entities;

namespace PIS.Core.Database.EntityConfigurations;

internal class StrRozvEntityTypeConfiguration : IEntityTypeConfiguration<StrRozv>
{
    public void Configure(EntityTypeBuilder<StrRozv> builder)
    {
        builder.HasKey(e => new { e.CdKp, e.CdSb, e.CdVyr, e.RivNb });

        builder.HasOne(e => e.Vyr)
            .WithMany()
            .HasForeignKey(e => e.CdVyr)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Sb)
            .WithMany()
            .HasForeignKey(e => e.CdSb)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Kp)
            .WithMany()
            .HasForeignKey(e => e.CdKp)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
