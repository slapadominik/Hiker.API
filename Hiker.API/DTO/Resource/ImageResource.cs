using Hiker.Application.Common.Consts;

namespace Hiker.API.DTO.Resource
{
    public class ImageResource
    {
        public string Url { get; }

        private ImageResource(string url)
        {
            Url = url;
        }

        public static ImageResource ForMountain(string serverAddress, string imageId, string imageType)
        {
            return new ImageResource($"{serverAddress}/{imageId.ToUpper()}.{imageType}");
        }
    }
}