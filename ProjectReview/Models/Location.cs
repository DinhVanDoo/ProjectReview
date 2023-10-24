using System;
using System.Collections.Generic;

namespace ProjectReview.Models
{
    public partial class Location
    {
        public Location()
        {
            Comments = new HashSet<Comment>();
            LocationImgs = new HashSet<LocationImg>();
            Rates = new HashSet<Rate>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Coordinates { get; set; }
        public int? StatusId { get; set; }
        public int? TypeId { get; set; }
        public int? VillageId { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual LocationStatus? Status { get; set; }
        public virtual LocationType? Type { get; set; }
        public virtual Village? Village { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<LocationImg> LocationImgs { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
    }
}
