using System;
using System.Drawing;
using Hiker.Application.Common.Consts;

namespace Hiker.Application.Common.Services.Interfaces
{
    public interface IImageService
    {
        byte[] GetRemoteImage(Uri uri, Guid imgId, ImageType imageType);
    }
}