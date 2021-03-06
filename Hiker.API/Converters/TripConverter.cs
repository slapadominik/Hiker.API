﻿using System.Linq;
using AutoMapper;
using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource.Command;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters
{
    public class TripConverter : ITripConverter
    {
        private readonly IMapper _mapper;
        private readonly ITripDestinationConverter _tripDestinationConverter;

        public TripConverter(ITripDestinationConverter tripDestinationConverter)
        {
            _tripDestinationConverter = tripDestinationConverter;
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddTripCommand, Trip>()
                    .ForMember(x => x.TripDestinations, opt => opt.Ignore())
                    .ForMember(x => x.TripParticipants, opt => opt.Ignore())
                    .ForMember(x => x.Author, opt => opt.Ignore());
                cfg.CreateMap<UpdateTrip, Trip>()
                    .ForMember(x => x.TripDestinations, opt => opt.Ignore())
                    .ForMember(x => x.TripParticipants, opt => opt.Ignore())
                    .ForMember(x => x.Author, opt => opt.Ignore());

            });
            _mapper = mapperConfig.CreateMapper();
        }
        public Trip Convert(AddTripCommand addTripCommand)
        {
            var trip = _mapper.Map<Trip>(addTripCommand);
            trip.TripDestinations = addTripCommand.TripDestinations?.Select(x => _tripDestinationConverter.Convert(x)).ToList();
            return trip;
        }

        public Trip Convert(int tripId, UpdateTrip updateTrip)
        {
            var trip = _mapper.Map<Trip>(updateTrip);
            trip.Id = tripId;
            trip.TripDestinations = updateTrip.TripDestinations?.Select(x => _tripDestinationConverter.Convert(x)).ToList();
            return trip;
        }
    }
}