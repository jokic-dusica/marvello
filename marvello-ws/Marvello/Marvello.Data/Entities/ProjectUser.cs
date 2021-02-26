using System;
using System.Collections.Generic;
using System.Text;

namespace Marvello.Data.Entities
{
    public class ProjectUser
    {
        public long ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
    }
}
