using System;
using System.Collections.Generic;

namespace ProjectReview.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            MessageToUsers = new HashSet<Message>();
            MessageUsers = new HashSet<Message>();
            Notifications = new HashSet<Notification>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Avatar { get; set; }
        public int? RoleId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Role? Role { get; set; }
        public virtual UserStatus? Status { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Message> MessageToUsers { get; set; }
        public virtual ICollection<Message> MessageUsers { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
