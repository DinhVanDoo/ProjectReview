using System;
using System.Collections.Generic;

namespace ProjectReview.Models
{
    public partial class Reply
    {
        public int? Id { get; set; }
        public string? Content { get; set; }
        public int? UserId { get; set; }
        public int? CommentId { get; set; }
        public DateTime? Date { get; set; }
        public int? LikeNumber { get; set; }

        public virtual Comment? Comment { get; set; }
    }
}
