using System;
using Hiker.API.DTO.Resource;
using Hiker.API.DTO.Resource.Command;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters.Interfaces
{
    public interface ITripConverter
    {
        Trip Convert(AddTripCommand addTripCommand);
        Trip Convert(int tripId, UpdateTrip addTripCommand);
    }
}