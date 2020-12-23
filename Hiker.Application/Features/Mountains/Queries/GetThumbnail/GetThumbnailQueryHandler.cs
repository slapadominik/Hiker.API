using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Hiker.API.Config;
using Hiker.Application.Common.Consts;
using Hiker.Application.Common.Exceptions;
using Hiker.Application.Common.Services.Interfaces;
using Hiker.Persistence.Repositories.Interfaces;
using MediatR;
using Microsoft.Extensions.Options;

namespace Hiker.Application.Features.Mountains.Queries.GetThumbnail
{
    public class GetThumbnailQueryHandler : IRequestHandler<GetThumbnailQuery, byte[]>
    {
        private readonly IImageService _imageService;
        private readonly IMountainsRepository _mountainsRepository;
        private readonly ResourcesOptions _options;

        public GetThumbnailQueryHandler(
            IImageService imageService, 
            IMountainsRepository mountainsRepository,
            IOptions<ResourcesOptions> config)
        {
            _imageService = imageService;
            _mountainsRepository = mountainsRepository;
            _options = config.Value;
        }

        public async Task<byte[]> Handle(GetThumbnailQuery request, CancellationToken cancellationToken)
        {
            var thumbnailId = await _mountainsRepository.GetMountainThumbnailIdAsync(request.MountainId);
            if (!thumbnailId.HasValue)
            {
                throw new EntityNotFoundException($"Entity not found");
            }
            return _imageService.GetRemoteImage(new Uri(_options.ImagesBaseAddress), thumbnailId.Value, ImageType.Jpeg);
        }
    }
}