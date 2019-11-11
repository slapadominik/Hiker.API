using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;
using MediatR;

namespace Hiker.Application.Features.Mountains.Queries.GetMountain
{
    public class GetMountainQueryHandler : IRequestHandler<GetMountainQuery,Mountain>
    {
        private readonly IMountainsRepository _mountainsRepository;

        public GetMountainQueryHandler(IMountainsRepository mountainsRepository)
        {
            _mountainsRepository = mountainsRepository;
        }

        public Task<Mountain> Handle(GetMountainQuery request, CancellationToken cancellationToken)
        {
            return _mountainsRepository.GetByIdAsync(request.MountainId);
        }
    }
}