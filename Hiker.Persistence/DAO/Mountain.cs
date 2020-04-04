using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hiker.Persistence.DAO
{
    public class Mountain
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int MetersAboveSeaLevel { get; set; }
        public Guid ThumbnailId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public IEnumerable<MountainTrail> MountainTrail { get; set; }
        public IEnumerable<MountainImage> MountainImages { get; set; }
        public IEnumerable<TripDestination> TripDestinations { get; set; }

        public Mountain()
        {
            MountainTrail = new List<MountainTrail>();
            MountainImages = new List<MountainImage>();
        }
    }
}