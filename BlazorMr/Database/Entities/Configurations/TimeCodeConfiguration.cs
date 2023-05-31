using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMr.Database.Entities.Configurations;

public class TimeCodeConfiguration : IEntityTypeConfiguration<TimeCode>
{
    public void Configure(EntityTypeBuilder<TimeCode> builder)
    {
        builder.ToTable("TimeCode");

        builder.HasOne(d => d.IdVideoNavigation).WithMany(p => p.TimeCodes)
            .HasForeignKey(d => d.IdVideo)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_TimeCode_Video");
    }
}