using System;
using System.Collections.Generic;

namespace ProjectReview.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int? UserId { get; set; }
        public int? LocationId { get; set; }
        public DateTime? Date { get; set; }
        public int? LikeNumber { get; set; }

        public virtual Location? Location { get; set; }
        public virtual User? User { get; set; }
    }
}
