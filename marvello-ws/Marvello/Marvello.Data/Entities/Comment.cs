using System;

namespace Marvello.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long TaskId { get; set; }
        public virtual Task Task { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
    }
}