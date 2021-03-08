using System;
using System.Collections.Generic;

namespace Marvello.Data.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Password { get; set; }
        public string PhotoUrl { get; set; }
        public int UserType { get; set; }
        public virtual List<ProjectUser> ProjectUsers { get; set; }
        public virtual List<Task> Tasks { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<RefreshToken> RefreshTokens { get; set; }

        public User()
        {
            ProjectUsers = new List<ProjectUser>();
            Tasks = new List<Task>();
            Comments = new List<Comment>();
            RefreshTokens = new List<RefreshToken>();
        }
    }
}