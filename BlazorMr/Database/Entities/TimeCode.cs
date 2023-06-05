using BlazorMr.Database.Entities.Common;

namespace BlazorMr.Database.Entities;

public class TimeCode : Entity
{
    public int IdVideo { get; set; }

    public short Start { get; set; }

    public string StartModified => TimeCodeTranslitter.Translit(Start);

    public short End { get; set; }

    public string EndModified => TimeCodeTranslitter.Translit(End);

    public Video IdVideoNavigation { get; set; } = null!;
}