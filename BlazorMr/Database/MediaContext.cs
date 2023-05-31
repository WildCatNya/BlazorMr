using BlazorMr.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlazorMr.Database;

public partial class MediaContext : DbContext
{
    public const string ConnectionStringName = "MediaConnection";

    public MediaContext() { }

    public MediaContext(DbContextOptions<MediaContext> options) : base(options) { }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<TimeCode> TimeCodes { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Media;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}