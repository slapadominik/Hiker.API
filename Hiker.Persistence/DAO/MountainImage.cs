using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hiker.Persistence.DAO
{
    public class MountainImage
    {
        public Guid ImageId { get; set; }
        public string FileExtensions { get; set; }
        public Mountain Mountain { get; set; }
        public int MountainId { get; set; }
    }
}
