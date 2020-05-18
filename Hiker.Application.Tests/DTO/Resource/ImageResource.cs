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
    }
}