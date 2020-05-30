using System;
using System.Collections.Generic;
using Hiker.Persistence.DAO;

namespace Hiker.API.DTO.Resource.Briefs
{
    public class TripBriefResource
    {
        public int? Id { get; set; }
        public string TripTitle { get; set; }
        public Guid AuthorId{ get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool IsOneDay { get; set; }
        public EnumerableBriefResource TripParticipants { get; set; }

        public TripBriefResource()
        {
            TripParticipants = new EnumerableBriefResource();
        }
    }
}