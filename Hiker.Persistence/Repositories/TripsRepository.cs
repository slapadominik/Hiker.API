﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hiker.Persistence.Repositories
{
    public class TripsRepository : ITripsRepository
    {
        private readonly AppDbContext _dbContext;

        public TripsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(Trip trip)
        {
            _dbContext.Trips.Add(trip);
            _dbContext.SaveChanges();
            return trip.Id;
        }

        public void Delete(Trip trip)
        {
            _dbContext.Trips.Remove(trip);
            _dbContext.SaveChanges();
        }

        public Task<Trip> GetBriefByIdAsync(int tripId)
        {
            return _dbContext.Trips.SingleOrDefaultAsync(x => x.Id == tripId);
        }

        public Task<Trip> GetDetailsByIdAsync(int tripId)
        {
            return _dbContext.Trips.Include(x=> x.Author)
                .Include(x => x.TripParticipants).ThenInclude(x => x.User)
                .Include(x => x.TripDestinations).ThenInclude(x => x.Mountain).ThenInclude(x => x.Location)
                .Include(x => x.TripDestinations).ThenInclude(x => x.Rock).ThenInclude(x => x.Location)
                .SingleOrDefaultAsync(x => x.Id == tripId);
        }

        public IEnumerable<Trip> GetByPredicate(Func<Trip, bool> predicate)
        {
       
            return _dbContext.Trips.Include(x => x.TripParticipants).Where(predicate);
        }
    }
}