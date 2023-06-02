using System.ComponentModel.DataAnnotations;

namespace BlazorMr.Preview;

public enum PreviewResolution
{
    [Display(Name = "1280x720")] MaxResDefault,
    [Display(Name = "640x480")] SdDefault,
    [Display(Name = "480x360")] HqDefault,
    [Display(Name = "320x180")] MqDefault,
    [Display(Name = "120x90")] Default,
}