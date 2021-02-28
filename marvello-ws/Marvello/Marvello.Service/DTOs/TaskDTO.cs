using System;
using System.Collections.Generic;
using System.Text;

namespace Marvello.Service.DTOs
{
    public class TaskDTO
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
        public DateTime? ModifiedOn { get; set; }
        public int StoryPoint { get; set; }
        public long ProjectId { get; set; }
        public long UserId { get; set; }
        public ProjectDTO Project { get; set; }
        public UserDTO User { get; set; }
    }
}
