using BlazorMr.Database.Entities.Common;

namespace BlazorMr.Database.Entities;

public class Video : Entity
{
    public int IdAuthor { get; set; }

    public string Title { get; set; } = null!;

    public string Href { get; set; } = null!;

    public bool IncognitoAccess { get; set; }

    public Author IdAuthorNavigation { get; set; } = null!;

    public ICollection<TimeCode> TimeCodes { get; } = new List<TimeCode>();
}