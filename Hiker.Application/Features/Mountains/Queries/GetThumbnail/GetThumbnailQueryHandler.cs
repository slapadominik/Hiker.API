using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Hiker.Application.Common.Consts;
using Hiker.Application.Common.Exceptions;
using Hiker.Application.Common.Services.Interfaces;
using Hiker.Persistence.Repositories.Interfaces;
using MediatR;

namespace Hiker.Application.Features.Mountains.Queries.GetThumbnail
{
    public class GetThumbnailQueryHandler : IRequestHandler<GetThumbnailQuery, byte[]>
    {
        private readonly IImageService _imageService;
        private readonly IMountainsRepository _mountainsRepository;

        public GetThumbnailQueryHandler(
            IImageService imageService, 
            IMountainsRepository mountainsRepository)
        {
            _imageService = imageService;
            _mountainsRepository = mountainsRepository;
        }

        public async Task<byte[]> Handle(GetThumbnailQuery request, CancellationToken cancellationToken)
        {
            var thumbnailId = await _mountainsRepository.GetMountainThumbnailIdAsync(request.MountainId);
            if (!thumbnailId.HasValue)
            {
                throw new EntityNotFoundException($"Entity not found");
            }
            return _imageService.GetRemoteImage(new Uri(AzureStorageConsts.ImagesUri), thumbnailId.Value, ImageType.Jpeg);
        }
    }
}