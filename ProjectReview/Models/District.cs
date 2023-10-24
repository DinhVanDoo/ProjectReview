using System;
using System.Collections.Generic;

namespace ProjectReview.Models
{
    public partial class District
    {
        public District()
        {
            Villages = new HashSet<Village>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CityId { get; set; }

        public virtual City? City { get; set; }
        public virtual ICollection<Village> Villages { get; set; }
    }
}
