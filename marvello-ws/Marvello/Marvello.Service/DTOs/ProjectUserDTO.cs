using System;
using System.Collections.Generic;
using System.Text;

namespace Marvello.Service.DTOs
{
    public class ProjectUserDTO
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public long UserId { get; set; }
        public ProjectDTO Project { get; set; }
        public UserDTO User { get; set; }
    }
}
