using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Hiker.Application.Common.Consts;
using Hiker.Application.Common.Exceptions;
using Hiker.Application.Common.Services.Interfaces;
using RestSharp;

namespace Hiker.Application.Common.Services
{
    public class ImageService : IImageService
    {
        private readonly IRestClient _restClient;

        public ImageService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public byte[] GetRemoteImage(Uri uri, Guid imgId, ImageType imageType)
        {
            var request = BuildGetRequest(uri, imageType, imgId.ToString());
            var result = _restClient.Execute(request);
            return result.IsSuccessful
                ? result.RawBytes
                : throw new RemoteEntityNotFoundException(
                    $"Remote service {uri} doesn't contain resource with Id {imgId}");
        }
        private RestRequest BuildGetRequest(Uri uri, ImageType imageType, string resourceId)
        {
            var request = new RestRequest($"{uri}" + "/{id}"+$".{imageType.Value}");
            request.AddUrlSegment("id", resourceId.ToUpper());
            request.AddHeader("Content-Type", "image/jpeg");
            return request;
        }
    }
}