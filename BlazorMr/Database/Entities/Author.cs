using BlazorMr.Database.Entities.Common;

namespace BlazorMr.Database.Entities;

public class Author : Entity
{
    public string Name { get; set; } = null!;

    public string Href { get; set; } = null!;

    public virtual ICollection<Video> Videos { get; } = new List<Video>();
}