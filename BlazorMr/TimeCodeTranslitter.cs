namespace BlazorMr;

public static class TimeCodeTranslitter
{
    public static string Translit(short timecode)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timecode);

        if (timeSpan.Hours > 0)
            return timeSpan.ToString(@"hh\:mm\:ss");

        return timeSpan.ToString(@"mm\:ss");
    }
}