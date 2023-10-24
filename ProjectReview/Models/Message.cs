using System;
using System.Collections.Generic;

namespace ProjectReview.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime? Date { get; set; }
        public int? UserId { get; set; }
        public int? ToUserId { get; set; }

        public virtual User? ToUser { get; set; }
        public virtual User? User { get; set; }
    }
}
