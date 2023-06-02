using BlazorMr.Database.Entities;

namespace BlazorMr.Preview;

public interface IPreviewManager
{
    public void Download(Video video);

    public void Download(Video video, PreviewResolution resolution);

    public void Delete(Video video);

    public bool HasPreview(Video video);

    public string GetHrefByRes(Video video, PreviewResolution resolution);
}