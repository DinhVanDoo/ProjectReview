using System;
using System.Collections.Generic;

namespace ProjectReview.Models
{
    public partial class LocationType
    {
        public LocationType()
        {
            Locations = new HashSet<Location>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
