﻿using BlazorMr.Data.DbModels;
using System.Net;

namespace BlazorMr;

public static class PreviewManager
{
    private static readonly string _basePath;
    private static readonly string _baseHref;
    static PreviewManager()
    {
        _basePath = @"wwwroot\images\video-previews";
        _baseHref = "http://i1.ytimg.com/vi";
    }
    public static void Download(Video video)
    {
        using WebClient client = new();
        try
        {
            Download(video, PreviewResolution.MaxResDefault);
        }
        catch (Exception)
        {
            try
            {
                Download(video, PreviewResolution.MqDefault);
            }
            catch (Exception)
            {
                Download(video, PreviewResolution.HqDefault);
            }
        }
    }
    public static void Download(Video video, PreviewResolution resolution)
    {
        DirectoryInfo directoryInfo = new(_basePath);
        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }
        using WebClient client = new();
        client.DownloadFile(GetHrefByRes(video, resolution), $@"{_basePath}\{video.Id}.jpg");
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
    public static string GetHrefByRes(Video video, PreviewResolution resolution)
    {
        string uniqId = video.Href.Replace("https://youtu.be/", string.Empty);

        return resolution switch
        {
            PreviewResolution.Default => $"{_baseHref}/{uniqId}/default.jpg",
            PreviewResolution.MaxResDefault => $"{_baseHref}/{uniqId}/maxresdefault.jpg",
            PreviewResolution.MqDefault => $"{_baseHref}/{uniqId}/mqdefault.jpg",
            PreviewResolution.SdDefault => $"{_baseHref}/{uniqId}/sddefault.jpg",
            PreviewResolution.HqDefault => $"{_baseHref}/{uniqId}/hqdefault.jpg",
            _ => throw new InvalidOperationException($"Отсутствует возвращаемое значение в методе {nameof(GetHrefByRes)} в классе {nameof(PreviewManager)}"),
        };
    }
}