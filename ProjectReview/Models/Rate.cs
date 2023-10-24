using System;
using System.Collections.Generic;

namespace ProjectReview.Models
{
    public partial class Rate
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int? LocationId { get; set; }

        public virtual Location? Location { get; set; }
    }
}
