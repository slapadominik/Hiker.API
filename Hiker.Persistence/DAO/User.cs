using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hiker.Persistence.DAO
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string FacebookId { get; set; }
        public string AboutMe { get; set; }
        public string PhoneNumber{ get; set; }

        public IEnumerable<Trip> CreatedTrips { get; set; }
        public IEnumerable<TripParticipant> TripParticipants { get; set; }

        public User()
        {
            CreatedTrips = new List<Trip>();
            TripParticipants = new List<TripParticipant>();
        }
    }
}