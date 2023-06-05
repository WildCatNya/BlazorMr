using BlazorMr.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlazorMr.Database;

public class MediaContext : DbContext
{
    public const string ConnectionStringName = "MediaConnection";

    public MediaContext(DbContextOptions<MediaContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Author> Authors { get; set; }

    public DbSet<TimeCode> TimeCodes { get; set; }

    public DbSet<Video> Videos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}