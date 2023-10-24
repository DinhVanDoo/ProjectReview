using System;
using System.Collections.Generic;

namespace ProjectReview.Models
{
    public partial class Village
    {
        public Village()
        {
            Locations = new HashSet<Location>();
        }

        public int Id { get; set; }
        public byte[]? Name { get; set; }
        public int? DistrictId { get; set; }

        public virtual District? District { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
