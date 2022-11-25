using System;
using System.Collections.Generic;

namespace BlazorMr.Data.DbModels;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Href { get; set; } = null!;

    public virtual ICollection<Video> Videos { get; } = new List<Video>();
}
