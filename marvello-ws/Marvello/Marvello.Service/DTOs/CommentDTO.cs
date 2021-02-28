using System;
using System.Collections.Generic;
using System.Text;

namespace Marvello.Service.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long TaskId { get; set; }
        public long UserId { get; set; }
        public UserDTO User { get; set; }
        public TaskDTO Task { get; set; }
    }
}
