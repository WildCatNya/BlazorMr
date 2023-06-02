using Azure;
using BlazorMr.Database.Entities;
using Org.BouncyCastle.Tsp;
using System.Net;

namespace BlazorMr.Preview;

public class PreviewManager : IPreviewManager
{
    private readonly string _imagesPath;
    private readonly string _downloadBasePath;
    private static readonly HttpClient _httpClient;

    static PreviewManager()
    {
        _httpClient = new();
    }

    public PreviewManager()
    {
        _imagesPath = @"wwwroot\images\video-previews";
        _downloadBasePath = "http://i1.ytimg.com/vi";
    }

    public async void Download(Video video)
    {
        foreach (PreviewResolution resolution in Enum.GetValues(typeof(PreviewResolution)))
        {
            HttpResponseMessage response = await _httpClient.GetAsync(GetHrefByRes(video, resolution));

            if (response.IsSuccessStatusCode)
            {
                Download(video, resolution, response);
                return;
            }
        }
    }

    public async void Download(Video video, PreviewResolution resolution)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(GetHrefByRes(video, resolution));

        if (response.IsSuccessStatusCode)
        {
            Download(video, resolution, response);
        }
    }

    private async void Download(Video video, PreviewResolution resolution, HttpResponseMessage response)
    {
        using (var fileStream = await response.Content.ReadAsStreamAsync())
        {
            // Specify the path and filename for saving the downloaded file
            string filePath = "C:\\path\\to\\save\\file.txt";

            using (var outputStream = new FileStream(filePath, FileMode.Create))
            {
                // Copy the content from the response stream to the file stream
                await fileStream.CopyToAsync(outputStream);
            }
        }
    }

    public string GetHrefByRes(Video video, PreviewResolution resolution)
    {
        string uniqId = video.Href.Replace("https://youtu.be/", string.Empty);

        return resolution switch
        {
            PreviewResolution.Default => $"{_downloadBasePath}/{uniqId}/default.jpg",
            PreviewResolution.MaxResDefault => $"{_downloadBasePath}/{uniqId}/maxresdefault.jpg",
            PreviewResolution.MqDefault => $"{_downloadBasePath}/{uniqId}/mqdefault.jpg",
            PreviewResolution.SdDefault => $"{_downloadBasePath}/{uniqId}/sddefault.jpg",
            PreviewResolution.HqDefault => $"{_downloadBasePath}/{uniqId}/hqdefault.jpg",
            _ => throw new InvalidOperationException($"Отсутствует возвращаемое значение в методе {nameof(GetHrefByRes)} в классе {nameof(PreviewManager)}"),
        };
    }

    public void Delete(Video video)
    {
        FileInfo file = GetFile(video);

        if (file.Exists)
            file.Delete();
    }

    public bool HasPreview(Video video) => GetFile(video).Exists;

    private FileInfo GetFile(Video video) => new($@"{_imagesPath}\{video.Id}.jpg");
}