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
        => optionsBuilder.UseSqlite("Data source=Media.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("Author");
        });

        modelBuilder.Entity<TimeCode>(entity =>
        {
            entity.ToTable("TimeCode");

            entity.HasOne(d => d.IdVideoNavigation).WithMany(p => p.TimeCodes)
                .HasForeignKey(d => d.IdVideo)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.ToTable("Video");

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Videos)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
