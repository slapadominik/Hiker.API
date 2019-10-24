using System;
using System.Collections.Generic;

namespace Hiker.API.DTO.Resource.Briefs
{
    public class TripBriefResource
    {
        public int? Id { get; set; }
        public string TripTitle { get; set; }
        public Guid? AuthorId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Description { get; set; }
        public UserBriefResource TripParticipants { get; set; }
    }
}