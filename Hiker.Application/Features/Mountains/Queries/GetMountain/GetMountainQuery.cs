using System.Collections.Generic;
using Hiker.Persistence.DAO;
using MediatR;

namespace Hiker.Application.Features.Mountains.Queries.GetMountain
{
    public class GetMountainQuery : IRequest<Mountain>
    {
        public int MountainId { get; }

        public GetMountainQuery(int mountainId)
        {
            MountainId = mountainId;
        }
    }
}