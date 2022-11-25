using System;
using System.Collections.Generic;

namespace BlazorMr.Data.DbModels;

public partial class TimeCode
{
    public int Id { get; set; }

    public int IdVideo { get; set; }

    public short Start { get; set; }

    public string StartModified => TimeCodeTranslitter.Translit(Start);

    public short End { get; set; }

    public string EndModified => TimeCodeTranslitter.Translit(End);

    public virtual Video IdVideoNavigation { get; set; } = null!;
}
