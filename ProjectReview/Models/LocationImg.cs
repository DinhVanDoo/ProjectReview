using System;
using System.Collections.Generic;

namespace ProjectReview.Models
{
    public partial class LocationImg
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public int? LocationId { get; set; }

        public virtual Location? Location { get; set; }
    }
}
