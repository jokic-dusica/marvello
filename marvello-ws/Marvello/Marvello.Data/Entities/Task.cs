using System;
using System.Collections.Generic;

namespace Marvello.Data.Entities
{
    public class Task
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public int Type { get; set; }
        public decimal Estimation { get; set; }
        public decimal TimeRemaining { get; set; }
        public decimal TimeSpent { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int StoryPoint { get; set; }       
        public long ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
        public long UserId { get; set; }
        public List<Comment> Comments { get; set; }

    }
}