using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMr.Database.Entities.Configurations;

public class VideoConfiguration : IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        builder.ToTable("Video");

        builder.Property(e => e.Href).HasMaxLength(60);
        builder.Property(e => e.Title).HasMaxLength(250);

        builder.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Videos)
            .HasForeignKey(d => d.IdAuthor)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Video_Author");
    }
}