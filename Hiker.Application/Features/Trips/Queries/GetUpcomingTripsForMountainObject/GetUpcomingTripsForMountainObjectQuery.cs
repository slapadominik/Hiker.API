using System;
using System.Collections.Generic;
using Hiker.Persistence.DAO;
using MediatR;

namespace Hiker.Application.Features.Trips.Queries.GetUpcomingTripsForMountainObject
{
    public class GetUpcomingTripsForMountainObjectQuery : IRequest<IEnumerable<Trip>>
    {
        public int TripDestinationType { get; set; }
        public int? MountainId { get; set; }
        public int? RockId { get; set; }
        public DateTime DateFrom { get; set; }
    }
}