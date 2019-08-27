using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;
using MediatR;

namespace Hiker.Application.Features.Mountains.Queries.GellMountains
{
    public class GetMountainsQueryHandler : IRequestHandler<GetMountainsQuery, IEnumerable<Mountain>>
    {
        private readonly IMountainsRepository _mountainsRepository;

        public GetMountainsQueryHandler(IMountainsRepository mountainsRepository)
        {
            _mountainsRepository = mountainsRepository;
        }

        public async Task<IEnumerable<Mountain>> Handle(GetMountainsQuery request, CancellationToken cancellationToken)
        {
            return await _mountainsRepository.GetAllAsync();
        }
    }
}