using BlazorMr.Data.DbModels;
using System.Net;

namespace BlazorMr;

public static class PreviewManager
{
    private static readonly string _basePath;
    static PreviewManager()
    {
        _basePath = @"wwwroot\images\video-previews";
    }
    public static void Download(Video video)
    {
        //default.jpg 120x90
        using (WebClient client = new())
        {
            DirectoryInfo directoryInfo = new(_basePath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            string uniqId = video.Href.Replace("https://youtu.be/", string.Empty);
            try
            {
                string href = $"http://i1.ytimg.com/vi/{uniqId}/maxresdefault.jpg"; //1280x720
                client.DownloadFile(href, $@"{_basePath}\{video.Id}.jpg");
            }
            catch (Exception)
            {
                try
                {
                    //string href = $"http://i1.ytimg.com/vi/{uniqId}/sddefault.jpg"; //640x480
                    string href = $"http://i1.ytimg.com/vi/{uniqId}/mqdefault.jpg"; //320x180
                    client.DownloadFile(href, $@"{_basePath}\{video.Id}.jpg");
                }
                catch (Exception)
                {
                    string href = $"http://i1.ytimg.com/vi/{uniqId}/hqdefault.jpg"; //480x360
                    client.DownloadFile(href, $@"{_basePath}\{video.Id}.jpg");
                }
            }
        }
    }
    public static void Delete(Video video)
    {
        FileInfo file = new($@"{_basePath}\{video.Id}.jpg");
        if (file.Exists)
        {
            file.Delete();
        }
    }
    public static bool HasPreview(Video video)
    {
        FileInfo file = new($@"{_basePath}\{video.Id}.jpg");
        return file.Exists;
    }
}