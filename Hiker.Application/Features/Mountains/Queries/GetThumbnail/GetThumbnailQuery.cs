using System.Drawing;
using System.IO;
using MediatR;

namespace Hiker.Application.Features.Mountains.Queries.GetThumbnail
{
    public class GetThumbnailQuery : IRequest<byte[]>
    {
        public int MountainId { get; }

        public GetThumbnailQuery(int mountainId)
        {
            MountainId = mountainId;
        }
    }
}