using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;
using MediatR;
using TripDestinationType = Hiker.Application.Common.Consts.TripDestinationType;

namespace Hiker.Application.Features.Trips.Queries.GetUpcomingTripsForMountainObject
{
    public class GetUpcomingTripsForMountainObjectQueryHandler : IRequestHandler<GetUpcomingTripsForMountainObjectQuery, IEnumerable<Trip>>
    {
        private readonly ITripDestinationRepository _tripDestinationRepository;

        public GetUpcomingTripsForMountainObjectQueryHandler(ITripDestinationRepository tripDestinationRepository)
        {
            _tripDestinationRepository = tripDestinationRepository;
        }

        public Task<IEnumerable<Trip>> Handle(GetUpcomingTripsForMountainObjectQuery request, CancellationToken cancellationToken)
        {
            if (request.TripDestinationType == (int) TripDestinationType.Mountain)
            {
                return Task.FromResult(_tripDestinationRepository
                    .GetUpcomingByMountainId(request.MountainId.Value, request.DateFrom)
                    .Select(x => x.Trip));
            }

            if (request.TripDestinationType == (int) TripDestinationType.Rock)
            {
                return Task.FromResult(_tripDestinationRepository
                    .GetUpcomingByRockId(request.RockId.Value, request.DateFrom)
                    .Select(x => x.Trip));
            }
            throw new InvalidOperationException("Wrong TripDestinationType value.");
        }
    }
}