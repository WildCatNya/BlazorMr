using System;
using System.Collections.Generic;

namespace BlazorMr.Data.DbModels;

public partial class Video
{
    public int Id { get; set; }

    public int IdAuthor { get; set; }

    public string Title { get; set; } = null!;

    public string Href { get; set; } = null!;

    public bool IncognitoAccess { get; set; }

    public virtual Author IdAuthorNavigation { get; set; } = null!;

    public virtual ICollection<TimeCode> TimeCodes { get; } = new List<TimeCode>();
}
