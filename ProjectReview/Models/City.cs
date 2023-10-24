using System;
using System.Collections.Generic;

namespace ProjectReview.Models
{
    public partial class City
    {
        public City()
        {
            Districts = new HashSet<District>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<District> Districts { get; set; }
    }
}
