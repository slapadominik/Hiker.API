﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hiker.Persistence.DAO
{
    public class Mountain
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int MetersAboveSeaLevel { get; set; }
        public IEnumerable<MountainTrail> MountainTrail { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public Mountain()
        {
            MountainTrail = new List<MountainTrail>();
        }
    }
}