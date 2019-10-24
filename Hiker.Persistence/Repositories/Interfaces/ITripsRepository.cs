﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;

namespace Hiker.Persistence.Repositories.Interfaces
{
    public interface ITripsRepository
    {
        Task<int> AddAsync(Trip trip);
        IEnumerable<Trip> GetByPredicate(Func<Trip, bool> predicate);
    }
}