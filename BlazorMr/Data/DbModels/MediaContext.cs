using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorMr.Data.DbModels;

public partial class MediaContext : DbContext
{
    public MediaContext()
    {
    }

    public MediaContext(DbContextOptions<MediaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<TimeCode> TimeCodes { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Media;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("Author");

            entity.Property(e => e.Href).HasMaxLength(60);
            entity.Property(e => e.Name).HasMaxLength(60);
        });

        modelBuilder.Entity<TimeCode>(entity =>
        {
            entity.ToTable("TimeCode");

            entity.HasOne(d => d.IdVideoNavigation).WithMany(p => p.TimeCodes)
                .HasForeignKey(d => d.IdVideo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TimeCode_Video");
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.ToTable("Video");

            entity.Property(e => e.Href).HasMaxLength(60);
            entity.Property(e => e.Title).HasMaxLength(250);

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Videos)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Video_Author");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
