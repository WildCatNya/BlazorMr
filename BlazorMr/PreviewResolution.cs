using System.ComponentModel.DataAnnotations;

namespace BlazorMr;

public enum PreviewResolution
{
    [Display(Name = "120x90")] Default,
    [Display(Name = "320x180")] MqDefault,
    [Display(Name = "480x360")] HqDefault,
    [Display(Name = "640x480")] SdDefault,
    [Display(Name = "1280x720")] MaxResDefault
}